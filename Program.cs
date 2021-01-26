using System;
using System.IO;

namespace SvgToRasterNugetTest
{
    class Program
    {
        const string XML_SVG_HEAD = @"<?xml version=""1.0"" encoding=""utf-8""?><!DOCTYPE svg PUBLIC ""-//W3C//DTD SVG 1.1//EN"" ""http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd"" >";

        static void Main(string[] args)
        {
            string svgJohnDoeSignature = @"<svg xmlns=""http://www.w3.org/2000/svg"" version=""1.1"" width=""1025"" height=""341"" style=""display:block"">
<g fill=""none"" stroke=""#000000"" stroke-width=""4"" stroke-linecap=""round"" stroke-linejoin=""round"">
<path d=""M 264 168.82 c -0.51 -0.73 -20.65 -27.66 -29 -42 c -4.4 -7.56 -7.57 -16.82 -10 -25 c -1.09 -3.66 -1 -8 -1 -12 c 0 -4.33 0.18 -9.08 1 -13 c 0.42 -2.01 1.79 -4.27 3 -6 c 1.02 -1.46 2.93 -2.53 4 -4 c 1.52 -2.09 2.26 -5.26 4 -7 c 3.23 -3.23 7.98 -6.68 12 -9 c 1.95 -1.13 4.75 -1.88 7 -2 c 3.72 -0.2 9.43 -0.2 12 1 c 1.43 0.67 2.38 3.91 3 6 c 1.99 6.71 4.14 13.9 5 21 c 1.8 14.84 2.62 29.55 3 45 c 0.65 26.71 0.5 51.3 0 78 c -0.19 9.95 -0.84 19.21 -2 29 c -1.22 10.25 -2.66 20.65 -5 30 c -0.86 3.44 -3.12 6.75 -5 10 c -1.82 3.15 -3.9 6.44 -6 9 c -0.7 0.85 -2.32 1.15 -3 2 c -1.78 2.23 -3 6.31 -5 8 c -1.81 1.53 -5.62 2.84 -8 3 c -2.03 0.14 -4.97 -0.98 -7 -2 c -2.4 -1.2 -5.08 -3.08 -7 -5 c -2.23 -2.23 -4.44 -5.27 -6 -8 c -0.99 -1.73 -1.92 -4.05 -2 -6 c -0.23 -5.86 0.05 -12.94 1 -19 c 0.68 -4.34 2.38 -8.68 4 -13 c 2.45 -6.54 4.88 -12.94 8 -19 c 2.52 -4.89 5.82 -9.35 9 -14 c 1.22 -1.79 2.57 -3.57 4 -5 c 0.8 -0.8 2.29 -1.15 3 -2 c 2.41 -2.89 4.47 -7.05 7 -10 c 1.33 -1.55 3.5 -2.5 5 -4 c 2.82 -2.82 5.65 -5.94 8 -9 c 0.87 -1.14 1.06 -3.06 2 -4 l 7 -5""/>
<path d=""M 310 141.82 c -0.14 0.07 -5.51 2.47 -8 4 c -1.78 1.1 -4.16 2.42 -5 4 c -1.5 2.82 -2.48 7.38 -3 11 c -0.45 3.17 -0.23 6.78 0 10 c 0.09 1.33 0.5 2.75 1 4 c 0.81 2.03 1.72 4.56 3 6 c 1.11 1.25 3.36 2.59 5 3 c 1.97 0.49 4.83 0.33 7 0 c 1.96 -0.3 4.05 -1.64 6 -2 c 1.55 -0.28 3.54 0.42 5 0 c 2.87 -0.82 6.76 -2.28 9 -4 c 1.64 -1.26 2.97 -3.93 4 -6 c 0.91 -1.81 1.78 -4.03 2 -6 c 0.42 -3.75 0.24 -8.14 0 -12 c -0.08 -1.33 -0.34 -2.93 -1 -4 c -1.81 -2.95 -4.43 -6.94 -7 -9 c -1.93 -1.54 -5.42 -2.4 -8 -3 c -1.51 -0.35 -3.62 -0.34 -5 0 l -3 2""/>
<path d=""M 311 140.82 c 0.02 0.1 0.3 4.59 1 6 c 0.42 0.83 2.11 2.12 3 2 c 3.12 -0.42 8.59 -2.03 12 -4 c 4.81 -2.77 10.11 -6.84 14 -11 c 5.15 -5.52 9.88 -12.37 14 -19 c 3.52 -5.66 6.58 -11.7 9 -18 c 6.99 -18.22 13.4 -36.33 19 -55 c 2.45 -8.18 3.09 -16.82 5 -25 c 0.4 -1.73 1.7 -3.37 2 -5 c 0.33 -1.82 0.37 -5.63 0 -6 c -0.26 -0.26 -2.39 1.89 -3 3 c -0.92 1.65 -1.1 4.11 -2 6 c -2.09 4.41 -4.98 8.49 -7 13 c -2.34 5.22 -3.67 10.91 -6 16 c -1.29 2.81 -3.86 5.35 -5 8 c -0.73 1.71 -0.4 4.08 -1 6 c -2.72 8.7 -6.37 17.1 -9 26 c -1.76 5.96 -2.3 11.97 -4 18 c -2.72 9.61 -6.59 18.59 -9 28 c -1.24 4.84 -0.81 10.25 -2 15 c -1.09 4.38 -3.86 8.58 -5 13 c -1.49 5.79 -3 17.68 -3 18 c 0 0.25 1.68 -9.59 3 -14 c 0.62 -2.07 2.38 -3.99 3 -6 c 0.65 -2.12 0.38 -4.74 1 -7 c 2.04 -7.38 4.18 -14.86 7 -22 c 2.18 -5.54 4.87 -11.89 8 -16 c 1.65 -2.17 6.37 -5 8 -5 c 1.01 0 2.42 3.25 3 5 c 1.65 4.96 3.1 10.62 4 16 c 0.76 4.58 0.9 9.2 1 14 c 0.25 12.31 -0.52 25.77 0 36 c 0.05 1.02 1.2 2.46 2 3 c 0.92 0.61 2.76 1 4 1 c 1.53 0 3.54 -0.45 5 -1 c 1.03 -0.39 3.1 -1.59 3 -2 l -4 -2""/>
<path d=""M 396 168.82 c 0.02 -0.07 0.41 -2.81 1 -4 c 3.93 -7.86 8.89 -15.77 13 -24 c 1.62 -3.25 2.44 -7.11 4 -10 c 0.61 -1.14 2.18 -2.86 3 -3 c 0.7 -0.12 2.62 1.16 3 2 c 0.74 1.66 1 4.66 1 7 c 0 9.92 -1.96 28.83 -1 30 c 0.68 0.84 6.93 -12.45 10 -19 c 1.99 -4.25 2.95 -8.9 5 -13 c 2.25 -4.5 5.27 -9.28 8 -13 c 0.64 -0.88 2.78 -2.38 3 -2 c 0.55 0.96 1.1 6.04 1 9 c -0.23 6.9 -1.7 13.85 -2 21 c -0.38 8.82 -0.67 17.7 0 26 c 0.3 3.64 1.22 8.92 3 11 l 9 3""/>
<path d=""M 584 68.82 c 0.18 0.91 6.79 34.22 10 52 c 0.55 3.04 0.92 5.94 1 9 c 0.26 9.45 1.43 20.24 0 28 c -0.62 3.38 -4.41 7.04 -7 10 c -1.95 2.23 -4.46 4.62 -7 6 c -4.45 2.42 -11.31 6.95 -15 6 c -5.71 -1.47 -15.26 -9.41 -20 -15 c -3.74 -4.41 -6.22 -11.9 -8 -18 c -2.12 -7.23 -2.93 -15.08 -4 -23 c -1.33 -9.89 -2.37 -19.15 -3 -29 c -0.39 -6.08 -0.68 -12.23 0 -18 c 0.62 -5.29 1.89 -11.59 4 -16 c 1.54 -3.22 5.12 -6.3 8 -9 c 2.39 -2.24 5.17 -4.25 8 -6 c 4.18 -2.59 8.47 -5.11 13 -7 c 7.47 -3.11 15.19 -5.8 23 -8 c 5.22 -1.47 10.67 -2.39 16 -3 c 3.27 -0.38 6.95 -0.41 10 0 c 1.64 0.22 3.63 1.09 5 2 c 1.44 0.96 2.85 2.52 4 4 c 3.5 4.5 6.83 9.08 10 14 c 3.64 5.64 7.16 11.32 10 17 c 1.05 2.1 1.65 4.62 2 7 c 0.97 6.56 1.53 13.11 2 20 c 0.56 8.23 1.19 15.99 1 24 c -0.15 6.37 -1.09 12.62 -2 19 c -0.44 3.08 -1.1 6.3 -2 9 c -0.35 1.06 -1.13 2.33 -2 3 c -3.14 2.41 -7.23 5.02 -11 7 c -2.47 1.3 -5.27 2.24 -8 3 c -3.26 0.91 -6.67 1.7 -10 2 l -12 0""/>
<path d=""M 684 121.82 c -0.07 -0.02 -2.76 -1 -4 -1 c -1.53 0 -3.56 0.33 -5 1 c -3.29 1.54 -6.91 3.86 -10 6 c -1.13 0.78 -2.34 1.87 -3 3 c -1.53 2.63 -2.92 5.98 -4 9 c -0.56 1.56 -1 3.42 -1 5 c 0 1.88 0.17 4.34 1 6 c 2.27 4.54 5.72 10.72 9 14 c 1.68 1.68 5.37 2.72 8 3 c 6.17 0.66 13.37 0.25 20 0 c 2.02 -0.08 4.24 -0.36 6 -1 c 1.69 -0.61 4.11 -1.73 5 -3 c 1.11 -1.59 1.15 -4.87 2 -7 c 0.42 -1.06 1.8 -1.99 2 -3 c 0.39 -1.95 0.65 -5.05 0 -7 c -1.17 -3.5 -3.81 -7.49 -6 -11 c -1.12 -1.79 -2.42 -3.81 -4 -5 c -3.43 -2.58 -8.29 -4.52 -12 -7 c -1.13 -0.76 -1.85 -2.67 -3 -3 l -18 -3""/>
<path d=""M 715 139.82 c 0.51 -0.11 20 -3.4 29 -6 c 3.13 -0.91 7.11 -2.84 9 -5 c 2.22 -2.54 4.14 -7.79 5 -11 c 0.29 -1.1 -0.53 -2.74 -1 -4 c -0.51 -1.36 -0.99 -3.3 -2 -4 c -2.72 -1.89 -7.62 -4.25 -11 -5 c -1.98 -0.44 -5.05 0.29 -7 1 c -1.38 0.5 -2.66 1.92 -4 3 c -2.1 1.68 -4.61 3.14 -6 5 c -1.36 1.81 -2.78 4.75 -3 7 c -0.38 3.84 0.32 8.93 1 13 c 0.28 1.68 1.11 3.76 2 5 c 0.59 0.83 2.26 1.17 3 2 c 1.77 1.99 3.08 5.08 5 7 c 2.23 2.23 5.31 4.89 8 6 c 2.43 1 6.51 1.36 9 1 c 1.6 -0.23 3.26 -2.45 5 -3 c 4.28 -1.35 9.59 -1.68 14 -3 c 2.07 -0.62 4.14 -1.8 6 -3 l 8 -6""/>
<text x=""984.08"" y=""320.54"" fill=""#C2BEBD"" stroke=""#C2BEBD"" stroke-width=""1"" font-family=""arial"" font-size=""40.92"" text-anchor=""end"">1/18/2021</text>
</g>
</svg>";
            int width = 1025; // $TO-DO: compute or get from SVG above.
            int height = 341;

            string svgFile = /*XML_SVG_HEAD + */ svgJohnDoeSignature;

            string whiteCanvas = $"<rect x=\"0\" y=\"0\" width=\"{width}\" height=\"{height}\" style=\"stroke:#FFFFFF; fill: #FFFFFF\"/>";
            int firstPath = svgFile.IndexOf("<path");
            if (firstPath > 0)
            {
                string opaqueSvg = svgFile.Substring(0, firstPath) + whiteCanvas + svgFile.Substring(firstPath);
                byte[] pngBytes = convertToImage(opaqueSvg);

                System.IO.File.WriteAllBytes(@"C:\temp\test.png", pngBytes);

                if (pngBytes.Length > 0)
                {
                    byte[] jpegBytes = ConvertPngToJpg(pngBytes);
                    System.IO.File.WriteAllBytes(@"C:\temp\test.jpg", pngBytes);
                }
            }
        }
        internal static byte[] convertToImage(string svg)  // $TO-DO: chane to "internal" after unit-testing
        {
            byte[] result = Array.Empty<byte>();

            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();

            try
            {
                xmlDoc.LoadXml(svg);

                Svg.SvgDocument svgDoc = Svg.SvgDocument.Open(xmlDoc);
                System.Drawing.Bitmap img = svgDoc.Draw();

                System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
                result = (byte[])converter.ConvertTo(img, typeof(byte[]));
            }
            catch
            {
                return result;
            }

            return result;
        }


        internal static byte[] ConvertPngToJpg(byte[] pngByteArray) // $TO-DO: chane to "internal" after unit-testing
        {
            MemoryStream pngStream = new MemoryStream(pngByteArray);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(pngStream);
            MemoryStream jpgStream = new MemoryStream();
            returnImage.Save(jpgStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] returnValue = jpgStream.ToArray(); // StreamToByteArray(jpgStream);

            return returnValue;
        }

    }
}
