Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization


Partial Class MASTER_Change_Password
    Inherits System.Web.UI.Page
    Dim conn As New SqlConnection(ConfigurationManager.AppSettings("ConnectionStringPORTAL"))
    Dim acs As New HelperClass
    Dim _AdminClass As New AdminClass
    Dim msg As String = ""
    Dim prmUser As New SqlParameter("USERNAME", SqlDbType.VarChar)
    Dim prmPwd As New SqlParameter("PWD", SqlDbType.VarChar)
    Dim prmOLD_PASWORD As New SqlParameter("OLD_PASWORD", SqlDbType.VarChar)

    Protected Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Error
        Dim PhyFilePath As String = System.AppDomain.CurrentDomain.BaseDirectory
        Dim sUser As String = Session("UserCode")
        Dim sLastError As String = Server.GetLastError.Message.ToString
        Dim sStackTrace As String = Server.GetLastError.StackTrace.ToString
        acs.WriteError(sLastError, sStackTrace, sUser, PhyFilePath, "Geeta Nutri Heal - Change Password")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        txt_oldpassword.Attributes.Add("onkeypress", "keyEnterCheck();")
        txt_oldpassword.Attributes.Add("oncopy", "return false;")
        txt_oldpassword.Attributes.Add("onpaste", "return false;")
        txt_newpassword.Attributes.Add("oncopy", "return false;")
        txt_newpassword.Attributes.Add("onpaste", "return false;")
        txt_confirmpassword.Attributes.Add("oncopy", "return false;")
        txt_confirmpassword.Attributes.Add("onpaste", "return false;")
        txt_oldpassword.Attributes.Add("autocomplete", "off")
        txt_newpassword.Attributes.Add("autocomplete", "off")
        txt_confirmpassword.Attributes.Add("autocomplete", "off")
       


        lbl_NewPassword.Visible = True
        txt_newpassword.Visible = True
        'txt_newpassword.Enabled = False
        lbl_ConfirmPassword.Visible = True
        txt_confirmpassword.Visible = True
        'txt_confirmpassword.Enabled = False
        'btn_ChangePassword.Enabled = False
        btn_ChangePassword.Visible = True


        If Session("UserCode") = "" Then
            Response.Redirect(acs.mapLink(Request.Path))
        End If
        If Not Page.IsPostBack Then
            'To Check User Rights....
            Dim strchk As String = acs.CheckSession(Session("UserCode"), System.IO.Path.GetFileName(Request.PhysicalPath))
            If strchk = "INVALID" Then
                Session("HomeFlag") = "N"
                Session("UserCode") = ""
                Response.Redirect(acs.mapLink(Request.Path))
            End If

            Dim query As String = "select CountryId, County from Country"
            BindDropDownList(ddlCountries, query, "County", "CountryId", "Select Country")
            pop_username()
        End If
    End Sub
    Protected Sub btn_ChangePassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ChangePassword.Click
        Dim cmdDelete As New SqlCommand
        Dim cmdInsert As New SqlCommand

        If txt_oldpassword.Text = "" Then
            Tell.text("Please Enter Old Password", Me)
            RequiredFieldValidator2.Visible = False
            RequiredFieldValidator3.Visible = False
            'btn_ChangePassword.Enabled = False
            Exit Sub
        End If

        msg = acs.ValidateText(txt_oldpassword.Text.Trim, "Old Pasword", 100)
        If msg <> "Y" Then
            Tell.text(msg, Me)
            txt_oldpassword.Text = ""
            Exit Sub
        End If

        msg = acs.ValidateText(txt_newpassword.Text.Trim, "New Pasword", 100)
        If msg <> "Y" Then
            Tell.text(msg, Me)
            txt_newpassword.Text = ""
            Exit Sub
        End If

        msg = acs.ValidateText(txt_confirmpassword.Text.Trim, "Confirm Pasword", 100)
        If msg <> "Y" Then
            Tell.text(msg, Me)
            txt_confirmpassword.Text = ""
            Exit Sub
        End If

        If txt_newpassword.Text.Trim <> txt_confirmpassword.Text.Trim Then
            Tell.text("New Password and Confirm Password Does Not Match", Me)
            txt_newpassword.Text = ""
            txt_confirmpassword.Text = ""
            txt_oldpassword.Focus()
            Exit Sub
        End If

        'Added for opening keys for encryption
        Dim cmd As New SqlCommand()
        'cmd.CommandText = "openkeys"
        'cmd.Connection = conn
        'cmd.CommandType = CommandType.StoredProcedure
        'If conn.State = ConnectionState.Closed Then conn.Open()
        'cmd.ExecuteNonQuery()

        Session("OldPassword") = txt_oldpassword.Text
        Dim _chk As Integer
        Dim _Str As String = "SELECT COUNT ( * )  " & _
                            "FROM ADMIN_MAPS_USER_MASTER " & _
                            "WHERE UPPER(USER_NAME) = UPPER(@USERNAME) AND USER_PASSWORD = @OLD_PASWORD "

        Dim _Cmd As New SqlCommand(_Str, conn)

        _Cmd.Parameters.Add(prmUser)
        _Cmd.Parameters.Add(prmOLD_PASWORD)
        prmUser.Value = Session("UserCode")
        prmOLD_PASWORD.Value = txt_oldpassword.Text

        If conn.State = ConnectionState.Closed Then conn.Open()
        _chk = _Cmd.ExecuteScalar
        _Cmd.Parameters.Clear()

        If conn.State = ConnectionState.Open Then conn.Close()
        If _chk = 0 Then

            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "message", "alert('Invalid Password.Please login and continue.');location.href = '../MASTER/index.aspx';", True)
            Session.Abandon()
            Session.Clear()
            Session.RemoveAll()

            If Request.Cookies("ASP.NET_SessionId") IsNot Nothing Then
                Response.Cookies("ASP.NET_SessionId").Value = String.Empty
                Response.Cookies("ASP.NET_SessionId").Expires = DateTime.UtcNow.AddHours(5.5).AddMonths(-20)
            End If

            Response.Cookies.Clear()
            Exit Sub
        End If


        If txt_newpassword.Text = Session("OldPassword") Then
            Tell.text("PASSWORD CAN NOT BE SAME AS PREVIOUS PASSWORD...", Me)
            Exit Sub
        End If
        If txt_confirmpassword.Text.Length < 8 Then
            Tell.text("PASSWORD SHOULD BE OF MINIMUM 8 CHARCTER...", Me)
            Exit Sub
        End If

        If Regex.IsMatch(txt_newpassword.Text, "((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*]).{8,20})") = False Then
            Tell.text("Password must have atleast 1 UpperCase Character and 1 Special Character", Me)
            SetFocus(txt_oldpassword)
            txt_oldpassword.Text = ""
            txt_newpassword.Text = ""
            txt_confirmpassword.Text = ""
            txt_oldpassword.Focus()
            Exit Sub
        End If



        If txt_confirmpassword.Text = Session("UserCode") Then
            Tell.text("PASSWORD CANT BE SAME AS USERNAME...", Me)
            Exit Sub
        End If

        'txt_oldpwd.Text = Session("OldPassword")

        cmd = New SqlCommand()

        'cmd.CommandText = "openkeys"
        'cmd.Connection = conn
        'cmd.CommandType = CommandType.StoredProcedure
        'If conn.State = ConnectionState.Closed Then conn.Open()
        'cmd.ExecuteNonQuery()

        Dim _StrUpdate As String = " UPDATE admin_maps_user_master  " & _
                                    " SET user_password    = @PWD, PASSWORD_DATE =dateadd(minute,330,getutcdate()) " & _
                                    " WHERE UPPER(user_name) = UPPER(@USERNAME) "
        Dim _cmdUpdate As New SqlCommand(_StrUpdate, conn)


        Dim cmdCount As New SqlCommand
        cmdCount.Connection = conn
        cmdCount.CommandText = "SELECT COUNT(*) FROM ADMIN_MAPS_PASSWORD_HISTORY WHERE UPPER(USER_NAME)=UPPER(@USERNAME) AND convert(varchar,DECRYPTBYKEY(NEW_PASSWORD))=@PWD"
        cmdCount.Parameters.Add(prmUser)
        cmdCount.Parameters.Add(prmPwd)
        prmUser.Value = Session("UserCode")
        prmPwd.Value = txt_confirmpassword.Text.Trim
        If conn.State = ConnectionState.Closed Then conn.Open()
        Dim pwdCnt As Int16 = cmdCount.ExecuteScalar
        cmdCount.Parameters.Clear()
        If pwdCnt > 0 Then
            Tell.text("Password is already used", Me)
            txt_newpassword.Text = ""
            txt_confirmpassword.Text = ""
            SetFocus(txt_newpassword)
            btn_ChangePassword.Enabled = True
            txt_newpassword.Enabled = True
            txt_confirmpassword.Enabled = True
            Exit Sub
        End If

        cmdCount.CommandText = "SELECT COUNT(*) FROM ADMIN_MAPS_PASSWORD_HISTORY WHERE UPPER(USER_NAME)= UPPER(@USERNAME) "
        cmdCount.Parameters.Add(prmUser)
        If conn.State = ConnectionState.Closed Then conn.Open()
        pwdCnt = cmdCount.ExecuteScalar
        cmdCount.Parameters.Clear()

        If pwdCnt > 5 Then
            cmdDelete.CommandText = "DELETE FROM ADMIN_MAPS_PASSWORD_HISTORY WHERE UPPER(USER_NAME)=UPPER(@USERNAME) AND PASSWORD_DATE=(SELECT MIN(PASSWORD_DATE) FROM ADMIN_MAPS_PASSWORD_HISTORY WHERE UPPER(USER_NAME)=UPPER(@USERNAME) ) "
            cmdDelete.Connection = conn
            cmdDelete.Parameters.Add(prmUser)
            If conn.State = ConnectionState.Closed Then conn.Open()
            cmdDelete.ExecuteNonQuery()
            cmdDelete.Parameters.Clear()
        End If


        '' Insert into Password History table
        cmdInsert.CommandText = "INSERT INTO ADMIN_MAPS_PASSWORD_HISTORY VALUES ( (SELECT isnull(MAX(CHANGE_COUNT),0)+1 FROM ADMIN_MAPS_PASSWORD_HISTORY WHERE USER_NAME=@USERNAME) ,dateadd(minute,330,getutcdate()),EncryptByKey(Key_GUID('Key_Encript'),@OLD_PASWORD),EncryptByKey(Key_GUID('Key_Encript'),@PWD),@USERNAME)"
        cmdInsert.Connection = conn
        cmdInsert.Parameters.Add(prmOLD_PASWORD)
        cmdInsert.Parameters.Add(prmPwd)
        cmdInsert.Parameters.Add(prmUser)
        prmOLD_PASWORD.Value = txt_oldpwd.Text
        If conn.State = ConnectionState.Closed Then conn.Open()
        cmdInsert.ExecuteScalar()
        cmdInsert.Parameters.Clear()
        ' Ends - 22-Mar-11 - Sunil - To Add Functionlity of Password 
        '---------------------------------------------------------------------------------------------
        _cmdUpdate.Parameters.Add(prmPwd)
        _cmdUpdate.Parameters.Add(prmUser)
        prmUser.Value = Session("UserCode")
        prmPwd.Value = txt_confirmpassword.Text

        If conn.State = ConnectionState.Closed Then conn.Open()
        _cmdUpdate.ExecuteNonQuery()
        If conn.State = ConnectionState.Open Then conn.Close()
        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "message", "alert('Password has been changed.Please login and continue');location.href = '../MASTER/index.aspx';", True)

        Session.Clear()
        Session.Abandon()
        Session.RemoveAll()
        If Request.Cookies("ASP.NET_SessionId") IsNot Nothing Then
            Response.Cookies("ASP.NET_SessionId").Value = String.Empty
            Response.Cookies("ASP.NET_SessionId").Expires = DateTime.UtcNow.AddHours(5.5).AddMonths(-20)
        End If
        Response.Cookies.Clear()


    End Sub
    'Protected Sub btn_OldPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_OldPassword.Click
    '    If txt_oldpassword.Text = "" Then
    '        Tell.text("Please Enter Old Password", Me)
    '        RequiredFieldValidator2.Visible = False
    '        RequiredFieldValidator3.Visible = False
    '        btn_ChangePassword.Enabled = False
    '        Exit Sub
    '    End If

    '    msg = acs.ValidateText(txt_oldpassword.Text.Trim, "Old Pasword", 100)
    '    If msg <> "Y" Then
    '        Tell.text(msg, Me)
    '        txt_oldpassword.Text = ""
    '        Exit Sub
    '    End If

    '    'Added for opening keys for encryption
    '    Dim cmd As New SqlCommand()
    '    cmd.CommandText = "openkeys"
    '    cmd.Connection = conn
    '    cmd.CommandType = CommandType.StoredProcedure
    '    If conn.State = ConnectionState.Closed Then conn.Open()
    '    cmd.ExecuteNonQuery()

    '    Session("OldPassword") = txt_oldpassword.Text
    '    Dim _chk As Integer
    '    Dim _Str As String = "SELECT COUNT ( * )  " & _
    '                        "FROM ADMIN_MAPS_USER_MASTER " & _
    '                        "WHERE UPPER(USER_NAME) = UPPER(@USERNAME) AND convert(varchar,DECRYPTBYKEY(USER_PASSWORD)) = @OLD_PASWORD "

    '    Dim _Cmd As New SqlCommand(_Str, conn)

    '    _Cmd.Parameters.Add(prmUser)
    '    _Cmd.Parameters.Add(prmOLD_PASWORD)
    '    prmUser.Value = Session("UserCode")
    '    prmOLD_PASWORD.Value = txt_oldpassword.Text

    '    If conn.State = ConnectionState.Closed Then conn.Open()
    '    _chk = _Cmd.ExecuteScalar
    '    _Cmd.Parameters.Clear()

    '    If conn.State = ConnectionState.Open Then conn.Close()
    '    If _chk = 0 Then

    '        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "message", "alert('Invalid Password.Please login and continue.');location.href = '../MASTER/index.aspx';", True)
    '        Session.Abandon()
    '        Session.Clear()
    '        Session.RemoveAll()

    '        If Request.Cookies("ASP.NET_SessionId") IsNot Nothing Then
    '            Response.Cookies("ASP.NET_SessionId").Value = String.Empty
    '            Response.Cookies("ASP.NET_SessionId").Expires = DateTime.UtcNow.AddHours(5.5).AddMonths(-20)
    '        End If

    '        Response.Cookies.Clear()

    '    Else

    '        txt_oldpwd.Text = txt_oldpassword.Text
    '        lbl_NewPassword.Visible = True
    '        lbl_ConfirmPassword.Visible = True
    '        txt_newpassword.Visible = True
    '        txt_confirmpassword.Visible = True
    '        lnk_passwordStrength.Visible = True
    '        RequiredFieldValidator2.Visible = True
    '        RequiredFieldValidator3.Visible = True
    '        lbl_Dot_NewPassword.Visible = True
    '        lbl_Dot_ConfirmPassword.Visible = True
    '        btn_ChangePassword.Visible = True
    '        btn_OldPassword.Enabled = False
    '        txt_oldpassword.Enabled = False
    '        txt_confirmpassword.Enabled = True
    '        txt_newpassword.Enabled = True
    '        btn_ChangePassword.Enabled = True
    '        txt_newpassword.Focus()

    '    End If
    'End Sub

    Protected Sub txt_oldpassword_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_oldpassword.TextChanged
        ' Me.btn_OldPassword_Click(sender, e)
    End Sub

    Protected Sub lnk_passwordStrength_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk_passwordStrength.Click

    End Sub

    Private Sub pop_username()
        Dim d As New data
        Dim Strmcc As String = "select  IsNull(USER_FULL_NAME,'') ,IsNull(CLINIC_NAME,''),IsNull(REPORT_HEADING,''),IsNull(CONTACT1,''),IsNull(CONTACT2,''),IsNull(LANDLINE,''),IsNull(STD_CODE,''),IsNull(ADDRESS1,''),IsNull(QUALIFICATION1,''),IsNull(DOB,''),COUNTRY,STATE,CITY,GENDER from ADMIN_MAPS_user_master WHERE upper(USER_NAME)=upper('" + Session("UserCode") + "')"
        Dim dsmcc As DataSet = d.GetData(Strmcc)
        txtName.Text = dsmcc.Tables(0).Rows(0)(0)
        txtClinicName.Text = dsmcc.Tables(0).Rows(0)(1)
        txtReportHeading.Text = dsmcc.Tables(0).Rows(0)(2)
        txtContact.Text = dsmcc.Tables(0).Rows(0)(3)
        txtAlternateContact.Text = dsmcc.Tables(0).Rows(0)(4)
        txtLandline.Text = dsmcc.Tables(0).Rows(0)(5)
        txtStdCode.Text = dsmcc.Tables(0).Rows(0)(6)
        txtAddress.Text = dsmcc.Tables(0).Rows(0)(7)
        txtQualification.Text = dsmcc.Tables(0).Rows(0)(8)
        txtDOB.Text = dsmcc.Tables(0).Rows(0)(9)

        ddlCountries.Items.FindByText(dsmcc.Tables(0).Rows(0)(10)).Selected = True
        Country_Changed(Me.ddlCountries, System.EventArgs.Empty)
        'If dsmcc.Tables(0).Rows(0)(9) = "Male" Then
        ddlGender.SelectedValue = dsmcc.Tables(0).Rows(0)(13)
        ddlStates.Items.FindByText(dsmcc.Tables(0).Rows(0)(11)).Selected = True
        State_Changed(Me.ddlStates, System.EventArgs.Empty)

        ddlCities.Items.FindByText(dsmcc.Tables(0).Rows(0)(12)).Selected = True
        'End If
    End Sub

    Protected Sub btnProfile_Click(sender As Object, e As EventArgs)
        Dim dtdob As DateTime = DateTime.ParseExact(txtDOB.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture)

        Dim cmd As New SqlCommand()
        cmd.CommandText &= " UPDATE admin_maps_user_master  "
        cmd.CommandText &= "SET USER_FULL_NAME= '" & txtName.Text & "', "
        cmd.CommandText &= "CLINIC_NAME= '" & txtClinicName.Text & "', "
        cmd.CommandText &= "REPORT_HEADING= '" & txtReportHeading.Text & "', "
        cmd.CommandText &= "CONTACT1= '" & txtContact.Text & "', "
        cmd.CommandText &= "CONTACT2= '" & txtAlternateContact.Text & "', "
        cmd.CommandText &= "LANDLINE= '" & txtLandline.Text & "', "
        cmd.CommandText &= "STD_CODE= '" & txtStdCode.Text & "', "
        cmd.CommandText &= "COUNTRY= '" & ddlCountries.SelectedItem.Text & "', "
        cmd.CommandText &= "STATE= '" & ddlStates.SelectedItem.Text & "', "
        cmd.CommandText &= "CITY= '" & ddlCities.SelectedItem.Text & "', "
        cmd.CommandText &= "DOB= Cast('" & dtdob & "' as date), "
        cmd.CommandText &= "GENDER= '" & ddlGender.SelectedItem.Text & "', "
        cmd.CommandText &= "ADDRESS1= '" & txtAddress.Text & "', "
        cmd.CommandText &= "QUALIFICATION1= '" & txtQualification.Text & "'"
        cmd.CommandText &= "WHERE UPPER(user_name) = UPPER('" & Session("UserCode") & "') "
        cmd.Connection = conn
        If conn.State = ConnectionState.Closed Then conn.Open()
        cmd.ExecuteNonQuery()
        Tell.text("Profile has been Updated", Me)
    End Sub

    Private Sub BindDropDownList(ddl As DropDownList, query As String, text As String, value As String, defaultText As String)
        Dim conString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Dim cmd As New SqlCommand(query)
        Using con As New SqlConnection(conString)
            Using sda As New SqlDataAdapter()
                cmd.Connection = con
                con.Open()
                ddl.DataSource = cmd.ExecuteReader()
                ddl.DataTextField = text
                ddl.DataValueField = value
                ddl.DataBind()
                con.Close()
            End Using
        End Using
        ddl.Items.Insert(0, New ListItem(defaultText, "0"))
    End Sub

    Protected Sub Country_Changed(sender As Object, e As EventArgs)
        ddlStates.Enabled = False
        ddlCities.Enabled = False
        ddlStates.Items.Clear()
        ddlCities.Items.Clear()
        ddlStates.Items.Insert(0, New ListItem("Select State", "0"))
        ddlCities.Items.Insert(0, New ListItem("Select City", "0"))
        Dim countryId As Integer = Integer.Parse(ddlCountries.SelectedItem.Value)
        If countryId > 0 Then
            Dim query As String = String.Format("select StateId, State from countryState where CountryId = {0}", countryId)
            BindDropDownList(ddlStates, query, "State", "StateId", "Select State")
            ddlStates.Enabled = True
        End If
    End Sub

    Protected Sub State_Changed(sender As Object, e As EventArgs)
        ddlCities.Enabled = False
        ddlCities.Items.Clear()
        ddlCities.Items.Insert(0, New ListItem("Select City", "0"))
        Dim stateId As Integer = Integer.Parse(ddlStates.SelectedItem.Value)
        If stateId > 0 Then
            Dim query As String = String.Format("select CityId, City from stateCity where StateId = {0}", stateId)
            BindDropDownList(ddlCities, query, "City", "CityId", "Select City")
            ddlCities.Enabled = True
        End If
    End Sub

End Class
