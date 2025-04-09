using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FELRD.Models
{
    public partial class Helpers
    {
        public enum Actions
        {
            Add,
            Update,
            Delete
        }


        public enum Countries
        {
            [Description("Afganistán")]
            AF = 4,
            [Description("Islas Åland")]
            AX = 248,
            [Description("Albania")]
            AL = 8,
            [Description("Argelia")]
            DZ = 12,
            [Description("Samoa Americana")]
            AS = 16,
            [Description("Andorra")]
            AD = 20,
            [Description("Angola")]
            AO = 24,
            [Description("Anguila")]
            AI = 660,
            [Description("Antártida")]
            AQ = 10,
            [Description("Antigua y Barbuda")]
            AG = 28,
            [Description("Arabia Saudita")]
            SA = 682,
            [Description("Argentina")]
            AR = 32,
            [Description("Armenia")]
            AM = 51,
            [Description("Aruba")]
            AW = 533,
            [Description("Australia")]
            AU = 36,
            [Description("Austria")]
            AT = 40,
            [Description("Azerbaiyán")]
            AZ = 31,
            [Description("Bahamas")]
            BS = 44,
            [Description("Baréin")]
            BH = 48,
            [Description("Bangladés")]
            BD = 50,
            [Description("Barbados")]
            BB = 52,
            [Description("Bielorrusia")]
            BY = 112,
            [Description("Bélgica")]
            BE = 56,
            [Description("Belice")]
            BZ = 84,
            [Description("Benín")]
            BJ = 204,
            [Description("Bermudas")]
            BM = 60,
            [Description("Bután")]
            BT = 64,
            [Description("Bolivia")]
            BO = 68,
            [Description("Bonaire, San Eustaquio y Saba")]
            BQ = 535,
            [Description("Bosnia y Herzegovina")]
            BA = 70,
            [Description("Botsuana")]
            BW = 72,
            [Description("Brasil")]
            BR = 76,
            [Description("Territorio Británico del Océano Índico")]
            IO = 86,
            [Description("Brunéi")]
            BN = 96,
            [Description("Bulgaria")]
            BG = 100,
            [Description("Burkina Faso")]
            BF = 854,
            [Description("Burundi")]
            BI = 108,
            [Description("Cabo Verde")]
            CV = 132,
            [Description("Camboya")]
            KH = 116,
            [Description("Camerún")]
            CM = 120,
            [Description("Canadá")]
            CA = 124,
            [Description("República Centroafricana")]
            CF = 140,
            [Description("Chad")]
            TD = 148,
            [Description("Chile")]
            CL = 152,
            [Description("China")]
            CN = 156,
            [Description("Isla de Navidad")]
            CX = 162,
            [Description("Islas Cocos (Keeling)")]
            CC = 166,
            [Description("Colombia")]
            CO = 170,
            [Description("Comoras")]
            KM = 174,
            [Description("República del Congo")]
            CG = 178,
            [Description("República Democrática del Congo")]
            CD = 180,
            [Description("Islas Cook")]
            CK = 184,
            [Description("Costa Rica")]
            CR = 188,
            [Description("Costa de Marfil")]
            CI = 384,
            [Description("Croacia")]
            HR = 191,
            [Description("Cuba")]
            CU = 192,
            [Description("Curazao")]
            CW = 531,
            [Description("Chipre")]
            CY = 196,
            [Description("República Checa")]
            CZ = 203,
            [Description("Dinamarca")]
            DK = 208,
            [Description("Yibuti")]
            DJ = 262,
            [Description("Dominica")]
            DM = 212,
            [Description("República Dominicana")]
            DO = 214,
            [Description("Ecuador")]
            EC = 218,
            [Description("Egipto")]
            EG = 818,
            [Description("El Salvador")]
            SV = 222,
            [Description("Guinea Ecuatorial")]
            GQ = 226,
            [Description("Eritrea")]
            ER = 232,
            [Description("Estonia")]
            EE = 233,
            [Description("Suazilandia")]
            SZ = 748,
            [Description("Etiopía")]
            ET = 231,
            [Description("Islas Malvinas")]
            FK = 238,
            [Description("Islas Feroe")]
            FO = 234,
            [Description("Fiyi")]
            FJ = 242,
            [Description("Finlandia")]
            FI = 246,
            [Description("Francia")]
            FR = 250,
            [Description("Guayana Francesa")]
            GF = 254,
            [Description("Polinesia Francesa")]
            PF = 258,
            [Description("Territorios Australes y Antárticos Franceses")]
            TF = 260,
            [Description("Gabón")]
            GA = 266,
            [Description("Gambia")]
            GM = 270,
            [Description("Georgia")]
            GE = 268,
            [Description("Alemania")]
            DE = 276,
            [Description("Ghana")]
            GH = 288,
            [Description("Gibraltar")]
            GI = 292,
            [Description("Grecia")]
            GR = 300,
            [Description("Groenlandia")]
            GL = 304,
            [Description("Granada")]
            GD = 308,
            [Description("Guadalupe")]
            GP = 312,
            [Description("Guam")]
            GU = 316,
            [Description("Guatemala")]
            GT = 320,
            [Description("Guernsey")]
            GG = 831,
            [Description("Guinea")]
            GN = 324,
            [Description("Guinea-Bissau")]
            GW = 624,
            [Description("Guyana")]
            GY = 328,
            [Description("Haití")]
            HT = 332,
            [Description("Islas Heard y McDonald")]
            HM = 334,
            [Description("Ciudad del Vaticano")]
            VA = 336,
            [Description("Honduras")]
            HN = 340,
            [Description("Hong Kong")]
            HK = 344,
            [Description("Hungría")]
            HU = 348,
            [Description("Islandia")]
            IS = 352,
            [Description("India")]
            IN = 356,
            [Description("Indonesia")]
            ID = 360,
            [Description("Irán")]
            IR = 364,
            [Description("Irak")]
            IQ = 368,
            [Description("Irlanda")]
            IE = 372,
            [Description("Isla de Man")]
            IM = 833,
            [Description("Israel")]
            IL = 376,
            [Description("Italia")]
            IT = 380,
            [Description("Jamaica")]
            JM = 388,
            [Description("Japón")]
            JP = 392,
            [Description("Jersey")]
            JE = 832,
            [Description("Jordania")]
            JO = 400,
            [Description("Kazajistán")]
            KZ = 398,
            [Description("Kenia")]
            KE = 404,
            [Description("Kirguistán")]
            KG = 417,
            [Description("Kiribati")]
            KI = 296,
            [Description("Kuwait")]
            KW = 414,
            [Description("Laos")]
            LA = 418,
            [Description("Líbano")]
            LB = 422,
            [Description("Lesoto")]
            LS = 426,
            [Description("Letonia")]
            LV = 428,
            [Description("Liberia")]
            LR = 430,
            [Description("Libia")]
            LY = 434,
            [Description("Liechtenstein")]
            LI = 438,
            [Description("Lituania")]
            LT = 440,
            [Description("Luxemburgo")]
            LU = 442,
            [Description("Macao")]
            MO = 446,
            [Description("Madagascar")]
            MG = 450,
            [Description("Malasia")]
            MY = 458,
            [Description("Malawi")]
            MW = 454,
            [Description("Islas Maldivas")]
            MV = 462,
            [Description("Mali")]
            ML = 466,
            [Description("Malta")]
            MT = 470,
            [Description("Marruecos")]
            MA = 504,
            [Description("Martinica")]
            MQ = 474,
            [Description("Mauritania")]
            MR = 478,
            [Description("Mauricio")]
            MU = 480,
            [Description("Mayotte")]
            YT = 175,
            [Description("México")]
            MX = 484,
            [Description("Moldavia")]
            MD = 498,
            [Description("Mónaco")]
            MC = 492,
            [Description("Mongolia")]
            MN = 496,
            [Description("Montenegro")]
            ME = 499,
            [Description("Montserrat")]
            MS = 500,
            [Description("Mozambique")]
            MZ = 508,
            [Description("Myanmar")]
            MM = 104,
            [Description("Namibia")]
            NA = 516,
            [Description("Nauru")]
            NR = 520,
            [Description("Nepal")]
            NP = 524,
            [Description("Nicaragua")]
            NI = 558,
            [Description("Níger")]
            NE = 562,
            [Description("Nigeria")]
            NG = 566,
            [Description("Niue")]
            NU = 570,
            [Description("Isla Norfolk")]
            NF = 574,
            [Description("Noruega")]
            NO = 578,
            [Description("Nueva Caledonia")]
            NC = 540,
            [Description("Nueva Zelanda")]
            NZ = 554,
            [Description("Omán")]
            OM = 512,
            [Description("Países Bajos")]
            NL = 528,
            [Description("Pakistán")]
            PK = 586,
            [Description("Palaos")]
            PW = 585,
            [Description("Palestina")]
            PS = 275,
            [Description("Panamá")]
            PA = 591,
            [Description("Papúa Nueva Guinea")]
            PG = 598,
            [Description("Paraguay")]
            PY = 600,
            [Description("Perú")]
            PE = 604,
            [Description("Filipinas")]
            PH = 608,
            [Description("Polonia")]
            PL = 616,
            [Description("Portugal")]
            PT = 620,
            [Description("Puerto Rico")]
            PR = 630,
            [Description("Qatar")]
            QA = 634,
            [Description("Reino Unido")]
            GB = 826,
            [Description("Macedonia del Norte")]
            MK = 807,
            [Description("Sudán del Sur")]
            SS = 728,
            [Description("Reunión")]
            RE = 638,
            [Description("Ruanda")]
            RW = 646,
            [Description("Rumanía")]
            RO = 642,
            [Description("Rusia")]
            RU = 643,
            [Description("Sahara Occidental")]
            EH = 732,
            [Description("Samoa")]
            WS = 882,
            [Description("San Bartolomé")]
            BL = 652,
            [Description("San Cristóbal y Nieves")]
            KN = 659,
            [Description("San Marino")]
            SM = 674,
            [Description("San Martín (Francia)")]
            MF = 663,
            [Description("San Pedro y Miquelón")]
            PM = 666,
            [Description("San Vicente y las Granadinas")]
            VC = 670,
            [Description("Santa Elena, Ascensión y Tristán de Acuña")]
            SH = 654,
            [Description("Santa Lucía")]
            LC = 662,
            [Description("Santo Tomé y Príncipe")]
            ST = 678,
            [Description("Senegal")]
            SN = 686,
            [Description("Serbia")]
            RS = 688,
            [Description("Seychelles")]
            SC = 690,
            [Description("Sierra Leona")]
            SL = 694,
            [Description("Singapur")]
            SG = 702,
            [Description("San Martín (Países Bajos)")]
            SX = 534,
            [Description("Siria")]
            SY = 760,
            [Description("Somalia")]
            SO = 706,
            [Description("Sri Lanka")]
            LK = 144,
            [Description("Sudáfrica")]
            ZA = 710,
            [Description("Sudán")]
            SD = 729,
            [Description("Suecia")]
            SE = 752,
            [Description("Suiza")]
            CH = 756,
            [Description("Surinam")]
            SR = 740,
            [Description("Svalbard y Jan Mayen")]
            SJ = 744,
            [Description("Tayikistán")]
            TJ = 762,
            [Description("Tailandia")]
            TH = 764,
            [Description("Taiwán")]
            TW = 158,
            [Description("Tanzania")]
            TZ = 834,
            [Description("Timor Oriental")]
            TL = 626,
            [Description("Togo")]
            TG = 768,
            [Description("Tokelau")]
            TK = 772,
            [Description("Tonga")]
            TO = 776,
            [Description("Trinidad y Tobago")]
            TT = 780,
            [Description("Túnez")]
            TN = 788,
            [Description("Turkmenistán")]
            TM = 795,
            [Description("Turquía")]
            TR = 792,
            [Description("Tuvalu")]
            TV = 798,
            [Description("Ucrania")]
            UA = 804,
            [Description("Uganda")]
            UG = 800,
            [Description("Uruguay")]
            UY = 858,
            [Description("Uzbekistán")]
            UZ = 860,
            [Description("Vanuatu")]
            VU = 548,
            [Description("Venezuela")]
            VE = 862,
            [Description("Vietnam")]
            VN = 704,
            [Description("Wallis y Futuna")]
            WF = 876,
            [Description("Yemen")]
            YE = 887,
            [Description("Zambia")]
            ZM = 894,
            [Description("Zimbabue")]
            ZW = 716
        }


        public enum AmericaCountries
        {
            [Description("República Dominicana")]
            DO = 214,

            [Description("El Salvador")]
            SV = 222,

            [Description("Guatemala")]
            GT = 320,

            [Description("México")]
            MX = 484,

            [Description("Antigua y Barbuda")]
            AG = 28,

            [Description("Anguila")]
            AI = 660,

            [Description("Argentina")]
            AR = 32,

            [Description("Aruba")]
            AW = 533,

            [Description("Bahamas")]
            BS = 44,

            [Description("Barbados")]
            BB = 52,

            [Description("Belice")]
            BZ = 84,

            [Description("Bermudas")]
            BM = 60,

            [Description("Bolivia")]
            BO = 68,

            [Description("Bonaire, San Eustaquio y Saba")]
            BQ = 535,

            [Description("Brasil")]
            BR = 76,

            [Description("Canadá")]
            CA = 124,

            [Description("Chile")]
            CL = 152,

            [Description("Colombia")]
            CO = 170,

            [Description("Costa Rica")]
            CR = 188,

            [Description("Cuba")]
            CU = 192,

            [Description("Curazao")]
            CW = 531,

            [Description("Dominica")]
            DM = 212,

            [Description("Ecuador")]
            EC = 218,

            [Description("Guayana Francesa")]
            GF = 254,

            [Description("Granada")]
            GD = 308,

            [Description("Guadalupe")]
            GP = 312,

            [Description("Guyana")]
            GY = 328,

            [Description("Haití")]
            HT = 332,

            [Description("Honduras")]
            HN = 340,

            [Description("Jamaica")]
            JM = 388,

            [Description("Martinica")]
            MQ = 474,

            [Description("Montserrat")]
            MS = 500,

            [Description("Nicaragua")]
            NI = 558,

            [Description("Panamá")]
            PA = 591,

            [Description("Paraguay")]
            PY = 600,

            [Description("Perú")]
            PE = 604,

            [Description("Puerto Rico")]
            PR = 630,

            [Description("San Cristóbal y Nieves")]
            KN = 659,

            [Description("Santa Lucía")]
            LC = 662,

            [Description("San Martín (Francia)")]
            MF = 663,

            [Description("San Vicente y las Granadinas")]
            VC = 670,

            [Description("Surinam")]
            SR = 740,

            [Description("Trinidad y Tobago")]
            TT = 780,

            [Description("Uruguay")]
            UY = 858,

            [Description("Venezuela")]
            VE = 862
        }



    }
}
