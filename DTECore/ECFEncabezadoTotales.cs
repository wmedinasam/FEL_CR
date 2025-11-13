using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Globalization;

namespace DTECore
{
    public partial class ECFEncabezadoTotales : IXmlSerializable
    {
        public XmlSchema GetSchema() => null;

        private void WriteElementIf(XmlWriter writer, string name, decimal value, bool specified, string format = "0.00")
        {
            if (!specified) return;
            writer.WriteStartElement(name);
            writer.WriteString(value.ToString(format, CultureInfo.InvariantCulture));
            writer.WriteEndElement();
        }

        public void WriteXml(XmlWriter writer)
        {
            // 0: MontoGravadoTotal
            WriteElementIf(writer, "MontoGravadoTotal", MontoGravadoTotal, MontoGravadoTotalSpecified);

            // 1: MontoExento
            WriteElementIf(writer, "MontoExento", MontoExento, MontoExentoSpecified);

            // 2: MontoGravadoI1
            WriteElementIf(writer, "MontoGravadoI1", MontoGravadoI1, MontoGravadoI1Specified);

            // 3: MontoGravadoI3
            WriteElementIf(writer, "MontoGravadoI3", MontoGravadoI3, MontoGravadoI3Specified);

            // 4: ITBIS1 (sin decimales)
            WriteElementIf(writer, "ITBIS1", ITBIS1, ITBIS1Specified, "0");

            // 5: ITBIS3 (sin decimales)
            WriteElementIf(writer, "ITBIS3", ITBIS3, ITBIS3Specified, "0");

            // 6: TotalITBIS
            WriteElementIf(writer, "TotalITBIS", TotalITBIS, TotalITBISSpecified);

            // 7: TotalITBIS1
            WriteElementIf(writer, "TotalITBIS1", TotalITBIS1, TotalITBIS1Specified);

            // 8: TotalITBIS3
            WriteElementIf(writer, "TotalITBIS3", TotalITBIS3, TotalITBIS3Specified);

            // 9: TotalITBISRetenido
            WriteElementIf(writer, "TotalITBISRetenido", TotalITBISRetenido, TotalITBISRetenidoSpecified);

            // 10: TotalISRRetencion
            WriteElementIf(writer, "TotalISRRetencion", TotalISRRetencion, TotalISRRetencionSpecified);

            // 11: MontoTotal
            writer.WriteStartElement("MontoTotal");
            writer.WriteString(MontoTotal.ToString("0.00", CultureInfo.InvariantCulture));
            writer.WriteEndElement();

            // 12: SaldoAnterior
            WriteElementIf(writer, "SaldoAnterior", SaldoAnterior, SaldoAnteriorSpecified);
        }

        public void ReadXml(XmlReader reader)
        {
            if (reader.IsEmptyElement) { reader.Read(); return; }
            reader.ReadStartElement();

            while (reader.NodeType == XmlNodeType.Element)
            {
                string name = reader.LocalName;
                string raw = reader.ReadElementContentAsString();
                decimal val;
                decimal.TryParse(raw, NumberStyles.Number, CultureInfo.InvariantCulture, out val);

                switch (name)
                {
                    case "MontoGravadoTotal":
                        MontoGravadoTotal = val;
                        MontoGravadoTotalSpecified = true;
                        break;
                    case "MontoExento":
                        MontoExento = val;
                        MontoExentoSpecified = true;
                        break;
                    case "MontoGravadoI1":
                        MontoGravadoI1 = val;
                        MontoGravadoI1Specified = true;
                        break;
                    case "MontoGravadoI3":
                        MontoGravadoI3 = val;
                        MontoGravadoI3Specified = true;
                        break;
                    case "ITBIS1":
                        ITBIS1 = val;
                        ITBIS1Specified = true;
                        break;
                    case "ITBIS3":
                        ITBIS3 = val;
                        ITBIS3Specified = true;
                        break;
                    case "TotalITBIS":
                        TotalITBIS = val;
                        TotalITBISSpecified = true;
                        break;
                    case "TotalITBIS1":
                        TotalITBIS1 = val;
                        TotalITBIS1Specified = true;
                        break;
                    case "TotalITBIS3":
                        TotalITBIS3 = val;
                        TotalITBIS3Specified = true;
                        break;
                    case "TotalITBISRetenido":
                        TotalITBISRetenido = val;
                        TotalITBISRetenidoSpecified = true;
                        break;
                    case "TotalISRRetencion":
                        TotalISRRetencion = val;
                        TotalISRRetencionSpecified = true;
                        break;
                    case "MontoTotal":
                        MontoTotal = val;
                        break;
                    case "SaldoAnterior":
                        SaldoAnterior = val;
                        SaldoAnteriorSpecified = true;
                        break;
                    default:
                        // Ignorar elementos desconocidos
                        break;
                }
            }

            if (reader.NodeType == XmlNodeType.EndElement)
                reader.ReadEndElement();
        }
    }
}