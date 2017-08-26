﻿function pageLoad(sender, args) {
    $(document).ready(function () {

        var telInput = $("#ContentPlaceHolder1_ContentPlaceHolder3_txtMobile,#ContentPlaceHolder1_ContentPlaceHolder3_txtLandline");

        // initialise plugin
        telInput.intlTelInput({
            utilsScript: "../../Scripts/utils.js"
        });

        var selectedCountry = $("#ContentPlaceHolder1_ContentPlaceHolder3_ddlCountries option:selected");
        var aCountryCode = countryNameToCode("" + selectedCountry.text());
        telInput.intlTelInput("setCountry", aCountryCode);
    });

}

function countryNameToCode(countryName) {

    var arrCountryCode = new Array();
    arrCountryCode['Afghanistan'] = "AF";
    arrCountryCode['Albania'] = "AL";
    arrCountryCode['Algeria'] = "DZ";
    arrCountryCode['American Samoa'] = "AS";
    arrCountryCode['Andorra'] = "AD";
    arrCountryCode['Angola'] = "AO";
    arrCountryCode['Anguilla'] = "AI";
    arrCountryCode['Antarctica'] = "AQ";
    arrCountryCode['Antigua And Barbuda'] = "AG";
    arrCountryCode['Argentina'] = "AR";
    arrCountryCode['Armenia'] = "AM";
    arrCountryCode['Aruba'] = "AW";
    arrCountryCode['Ascension Island'] = "AC";
    arrCountryCode['Australia'] = "AU";
    arrCountryCode['Austria'] = "AT";
    arrCountryCode['Azerbaijan'] = "AZ";
    arrCountryCode['Bahamas'] = "BS";
    arrCountryCode['Bahrain'] = "BH";
    arrCountryCode['Bangladesh'] = "BD";
    arrCountryCode['Barbados'] = "BB";
    arrCountryCode['Belarus'] = "BY";
    arrCountryCode['Belgium'] = "BE";
    arrCountryCode['Belize'] = "BZ";
    arrCountryCode['Benin'] = "BJ";
    arrCountryCode['Bermuda'] = "BM";
    arrCountryCode['Bhutan'] = "BT";
    arrCountryCode['Bolivia'] = "BO";
    arrCountryCode['Bosnia And Herzegovina'] = "BA";
    arrCountryCode['Botswana'] = "BW";
    arrCountryCode['Bouvet Island'] = "BV";
    arrCountryCode['Brazil'] = "BR";
    arrCountryCode['British Indian Ocean Territory'] = "IO";
    arrCountryCode['Brunei'] = "BN";
    arrCountryCode['Bulgaria'] = "BG";
    arrCountryCode['Burkina Faso'] = "BF";
    arrCountryCode['Burundi'] = "BI";
    arrCountryCode['Cambodia'] = "KH";
    arrCountryCode['Cameroon'] = "CM";
    arrCountryCode['Canada'] = "CA";
    arrCountryCode['Cape Verde'] = "CV";
    arrCountryCode['Cayman Islands'] = "KY";
    arrCountryCode['Central African Republic'] = "CF";
    arrCountryCode['Chad'] = "TD";
    arrCountryCode['Chile'] = "CL";
    arrCountryCode['China'] = "CN";
    arrCountryCode['Christmas Island'] = "CX";
    arrCountryCode['Cocos (Keeling) Islands'] = "CC";
    arrCountryCode['Columbia'] = "CO";
    arrCountryCode['Comoros'] = "KM";
    arrCountryCode['Congo'] = "CG";
    arrCountryCode['Cook Islands'] = "CK";
    arrCountryCode['Costa Rica'] = "CR";
    arrCountryCode['Cote D\'Ivorie (Ivory Coast)'] = "CI";
    arrCountryCode['Croatia (Hrvatska)'] = "HR";
    arrCountryCode['Cuba'] = "CU";
    arrCountryCode['Cyprus'] = "CY";
    arrCountryCode['Czech Republic'] = "CZ";
    arrCountryCode['Democratic Republic Of Congo (Zaire)'] = "CD";
    arrCountryCode['Denmark'] = "DK";
    arrCountryCode['Djibouti'] = "DJ";
    arrCountryCode['Dominica'] = "DM";
    arrCountryCode['Dominican Republic'] = "DO";
    arrCountryCode['East Timor'] = "TL";
    arrCountryCode['Ecuador'] = "EC";
    arrCountryCode['Egypt'] = "EG";
    arrCountryCode['El Salvador'] = "SV";
    arrCountryCode['Equatorial Guinea'] = "GQ";
    arrCountryCode['Eritrea'] = "ER";
    arrCountryCode['Estonia'] = "EE";
    arrCountryCode['Ethiopia'] = "ET";
    arrCountryCode['Falkland Islands (Malvinas)'] = "FK";
    arrCountryCode['Faroe Islands'] = "FO";
    arrCountryCode['Fiji'] = "FJ";
    arrCountryCode['Finland'] = "FI";
    arrCountryCode['France'] = "FR";
    arrCountryCode['France, Metropolitan'] = "FX";
    arrCountryCode['French Guinea'] = "GF";
    arrCountryCode['French Polynesia'] = "PF";
    arrCountryCode['French Southern Territories'] = "TF";
    arrCountryCode['Gabon'] = "GA";
    arrCountryCode['Gambia'] = "GM";
    arrCountryCode['Georgia'] = "GE";
    arrCountryCode['Germany'] = "DE";
    arrCountryCode['Ghana'] = "GH";
    arrCountryCode['Gibraltar'] = "GI";
    arrCountryCode['Greece'] = "GR";
    arrCountryCode['Greenland'] = "GL";
    arrCountryCode['Grenada'] = "GD";
    arrCountryCode['Guadeloupe'] = "GP";
    arrCountryCode['Guam'] = "GU";
    arrCountryCode['Guatemala'] = "GT";
    arrCountryCode['Guinea'] = "GN";
    arrCountryCode['Guinea-Bissau'] = "GW";
    arrCountryCode['Guyana'] = "GY";
    arrCountryCode['Haiti'] = "HT";
    arrCountryCode['Heard And McDonald Islands'] = "HM";
    arrCountryCode['Honduras'] = "HN";
    arrCountryCode['Hong Kong'] = "HK";
    arrCountryCode['Hungary'] = "HU";
    arrCountryCode['Iceland'] = "IS";
    arrCountryCode['India'] = "IN";
    arrCountryCode['Indonesia'] = "ID";
    arrCountryCode['Iran'] = "IR";
    arrCountryCode['Iraq'] = "IQ";
    arrCountryCode['Ireland'] = "IE";
    arrCountryCode['Isle of Man'] = "IM";
    arrCountryCode['Israel'] = "IL";
    arrCountryCode['Italy'] = "IT";
    arrCountryCode['Jamaica'] = "JM";
    arrCountryCode['Japan'] = "JP";
    arrCountryCode['Jordan'] = "JO";
    arrCountryCode['Kazakhstan'] = "KZ";
    arrCountryCode['Kenya'] = "KE";
    arrCountryCode['Kiribati'] = "KI";
    arrCountryCode['Kuwait'] = "KW";
    arrCountryCode['Kyrgyzstan'] = "KG";
    arrCountryCode['Laos'] = "LA";
    arrCountryCode['Latvia'] = "LV";
    arrCountryCode['Lebanon'] = "LB";
    arrCountryCode['Lesotho'] = "LS";
    arrCountryCode['Liberia'] = "LR";
    arrCountryCode['Libya'] = "LY";
    arrCountryCode['Liechtenstein'] = "LI";
    arrCountryCode['Lithuania'] = "LT";
    arrCountryCode['Luxembourg'] = "LU";
    arrCountryCode['Macau'] = "MO";
    arrCountryCode['Macedonia'] = "MK";
    arrCountryCode['Madagascar'] = "MG";
    arrCountryCode['Malawi'] = "MW";
    arrCountryCode['Malaysia'] = "MY";
    arrCountryCode['Maldives'] = "MV";
    arrCountryCode['Mali'] = "ML";
    arrCountryCode['Malta'] = "MT";
    arrCountryCode['Marshall Islands'] = "MH";
    arrCountryCode['Martinique'] = "MQ";
    arrCountryCode['Mauritania'] = "MR";
    arrCountryCode['Mauritius'] = "MU";
    arrCountryCode['Mayotte'] = "YT";
    arrCountryCode['Mexico'] = "MX";
    arrCountryCode['Micronesia'] = "FM";
    arrCountryCode['Moldova'] = "MD";
    arrCountryCode['Monaco'] = "MC";
    arrCountryCode['Mongolia'] = "MN";
    arrCountryCode['Montenegro'] = "ME";
    arrCountryCode['Montserrat'] = "MS";
    arrCountryCode['Morocco'] = "MA";
    arrCountryCode['Mozambique'] = "MZ";
    arrCountryCode['Myanmar (Burma)'] = "MM";
    arrCountryCode['Namibia'] = "NA";
    arrCountryCode['Nauru'] = "NR";
    arrCountryCode['Nepal'] = "NP";
    arrCountryCode['Netherlands'] = "NL";
    arrCountryCode['Netherlands Antilles'] = "AN";
    arrCountryCode['New Caledonia'] = "NC";
    arrCountryCode['New Zealand'] = "NZ";
    arrCountryCode['Nicaragua'] = "NI";
    arrCountryCode['Niger'] = "NE";
    arrCountryCode['Nigeria'] = "NG";
    arrCountryCode['Niue'] = "NU";
    arrCountryCode['Norfolk Island'] = "NF";
    arrCountryCode['North Korea'] = "KP";
    arrCountryCode['Northern Mariana Islands'] = "MP";
    arrCountryCode['Norway'] = "NO";
    arrCountryCode['Oman'] = "OM";
    arrCountryCode['Pakistan'] = "PK";
    arrCountryCode['Palau'] = "PW";
    arrCountryCode['Palestine'] = "PS";
    arrCountryCode['Panama'] = "PA";
    arrCountryCode['Papua New Guinea'] = "PG";
    arrCountryCode['Paraguay'] = "PY";
    arrCountryCode['Peru'] = "PE";
    arrCountryCode['Philippines'] = "PH";
    arrCountryCode['Pitcairn'] = "PN";
    arrCountryCode['Poland'] = "PL";
    arrCountryCode['Portugal'] = "PT";
    arrCountryCode['Puerto Rico'] = "PR";
    arrCountryCode['Qatar'] = "QA";
    arrCountryCode['Reunion'] = "RE";
    arrCountryCode['Romania'] = "RO";
    arrCountryCode['Russia'] = "RU";
    arrCountryCode['Rwanda'] = "RW";
    arrCountryCode['Saint Helena'] = "SH";
    arrCountryCode['Saint Kitts And Nevis'] = "KN";
    arrCountryCode['Saint Lucia'] = "LC";
    arrCountryCode['Saint Pierre And Miquelon'] = "PM";
    arrCountryCode['Saint Vincent And The Grenadines'] = "VC";
    arrCountryCode['San Marino'] = "SM";
    arrCountryCode['Sao Tome And Principe'] = "ST";
    arrCountryCode['Saudi Arabia'] = "SA";
    arrCountryCode['Senegal'] = "SN";
    arrCountryCode['Serbia'] = "RS";
    arrCountryCode['Seychelles'] = "SC";
    arrCountryCode['Sierra Leone'] = "SL";
    arrCountryCode['Singapore'] = "SG";
    arrCountryCode['Slovak Republic'] = "SK";
    arrCountryCode['Slovenia'] = "SI";
    arrCountryCode['Solomon Islands'] = "SB";
    arrCountryCode['Somalia'] = "SO";
    arrCountryCode['South Africa'] = "ZA";
    arrCountryCode['South Georgia And South Sandwich Islan'] = "GS";
    arrCountryCode['South Korea'] = "KR";
    arrCountryCode['Spain'] = "ES";
    arrCountryCode['Sri Lanka'] = "LK";
    arrCountryCode['Sudan'] = "SD";
    arrCountryCode['Suriname'] = "SR";
    arrCountryCode['Svalbard And Jan Mayen'] = "SJ";
    arrCountryCode['Swaziland'] = "SZ";
    arrCountryCode['Sweden'] = "SE";
    arrCountryCode['Switzerland'] = "CH";
    arrCountryCode['Syria'] = "SY";
    arrCountryCode['Taiwan'] = "TW";
    arrCountryCode['Tajikistan'] = "TJ";
    arrCountryCode['Tanzania'] = "TZ";
    arrCountryCode['Thailand'] = "TH";
    arrCountryCode['Togo'] = "TG";
    arrCountryCode['Tokelau'] = "TK";
    arrCountryCode['Tonga'] = "TO";
    arrCountryCode['Trinidad And Tobago'] = "TT";
    arrCountryCode['Tunisia'] = "TN";
    arrCountryCode['Turkey'] = "TR";
    arrCountryCode['Turkmenistan'] = "TM";
    arrCountryCode['Turks And Caicos Islands'] = "TC";
    arrCountryCode['Tuvalu'] = "TV";
    arrCountryCode['Uganda'] = "UG";
    arrCountryCode['Ukraine'] = "UA";
    arrCountryCode['United Arab Emirates'] = "AE";
    arrCountryCode['United Kingdom'] = "GB";
    arrCountryCode['United States'] = "US";
    arrCountryCode['United States Minor Outlying Islands'] = "UM";
    arrCountryCode['Uruguay'] = "UY";
    arrCountryCode['Uzbekistan'] = "UZ";
    arrCountryCode['Vanuatu'] = "VU";
    arrCountryCode['Vatican City (Holy See)'] = "VA";
    arrCountryCode['Venezuela'] = "VE";
    arrCountryCode['Vietnam'] = "VN";
    arrCountryCode['Virgin Islands (British)'] = "VG";
    arrCountryCode['Virgin Islands (US)'] = "VI";
    arrCountryCode['Wallis And Futuna Islands'] = "WF";
    arrCountryCode['Western Sahara'] = "EH";
    arrCountryCode['Western Samoa'] = "WS";
    arrCountryCode['Yemen'] = "YE";
    arrCountryCode['Yugoslavia'] = "YU";
    arrCountryCode['Zambia'] = "ZM";
    arrCountryCode['Zimbabwe'] = "ZW";

    // TODO : Do we need to store country name in array while storing? I think we don't need it
    // that's why removing this code -- countryName.toUpperCase()
    var code = arrCountryCode[countryName];
    if (code === undefined) {
        return "";
    } else {
        return code;
    }
}