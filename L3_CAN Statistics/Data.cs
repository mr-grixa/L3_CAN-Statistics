using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

namespace L3_CAN_Statistics
{
    public struct CANDumpData
    {
        public UInt32 TickStamp;
        public byte Prefix;
        public byte Format;
        public byte Dest;
        public byte Source;
        public byte DLC;
        public byte b1;
        public byte b2;
        public byte b3;
        public byte b4;
        public byte b5;
        public byte b6;
        public byte b7;
        public byte b8;


        public CANDumpData(uint tickStamp, byte prefix, byte format, byte dest, byte source, byte dLC, byte b1, byte b2, byte b3, byte b4, byte b5, byte b6, byte b7, byte b8)
        {
            TickStamp = tickStamp;
            Prefix = prefix;
            Format = format;
            Dest = dest;
            Source = source;
            DLC = dLC;
            this.b1 = b1;
            this.b2 = b2;
            this.b3 = b3;
            this.b4 = b4;
            this.b5 = b5;
            this.b6 = b6;
            this.b7 = b7;
            this.b8 = b8;
        }
    }
    internal static class Data
    {
        public static DataTable TableFromCAN(List<CANDumpData> frames)
        {
            DataTable table = new DataTable();
            table.Columns.Add("TickStamp", typeof(UInt32));
            //table.Columns.Add("Prefix", typeof(byte));
            //table.Columns.Add("Format", typeof(byte));
            table.Columns.Add("Dest", typeof(byte));
            table.Columns.Add("Source", typeof(byte));
            //table.Columns.Add("DLC", typeof(byte));
            table.Columns.Add("b1", typeof(byte));
            //table.Columns.Add("b2", typeof(byte));
            //table.Columns.Add("b3", typeof(byte));
            //table.Columns.Add("b4", typeof(byte));
            //table.Columns.Add("b5", typeof(byte));
            //table.Columns.Add("b6", typeof(byte));
            //table.Columns.Add("b7", typeof(byte));
            //table.Columns.Add("b8", typeof(byte));

            foreach (CANDumpData data in frames)
            {
                DataRow row = table.NewRow();
                row["TickStamp"] = data.TickStamp;
                //row["Prefix"] = data.Prefix;
                //row["Format"] = data.Format;
                row["Dest"] = data.Dest;
                row["Source"] = data.Source;
                //row["DLC"] = data.DLC;
                row["b1"] = data.b1;
                //row["b2"] = data.b2;
                //row["b3"] = data.b3;
                //row["b4"] = data.b4;
                //row["b5"] = data.b5;
                //row["b6"] = data.b6;
                //row["b7"] = data.b7;
                //row["b8"] = data.b8;
                table.Rows.Add(row);
            }
            return table;
        }




    }
    internal static class Draw
    {
        public static Bitmap Сonnection(List<CANDumpData> dataList)
        {
            int width = 200; // Ширина битмапа
            int height = 200; // Высота битмапа
            int circleRadius = 70; // Радиус круга

            // Получение уникальных значений Source и Dest
            var uniqueValues = dataList.SelectMany(data => new[] { data.Source, data.Dest }).Distinct();
            int rectangleCount = uniqueValues.Count(); // Количество прямоугольников
            byte[] source = uniqueValues.ToArray();
            // Получение уникальных сочетаний Source и Dest
            var uniqueCombinations = dataList.Select(data => new { data.Source, data.Dest }).Distinct();


            // Создаем новый битмап
            Bitmap bitmap = new Bitmap(width, height);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                // Заливаем фон белым цветом
                graphics.Clear(Color.White);

                // Рассчитываем центр круга
                int centerX = width / 2;
                int centerY = height / 2;

                // Рассчитываем угол между прямоугольниками
                double angle = 2 * Math.PI / rectangleCount;
                for (int i = 0; i < rectangleCount; i++)
                {
                    // Рассчитываем координаты центра прямоугольника на окружности
                    int x = (int)(centerX + circleRadius * Math.Cos(i * angle));
                    int y = (int)(centerY + circleRadius * Math.Sin(i * angle));
                    for (int j = 0; j < i; j++)
                    {
                        int x1 = (int)(centerX + circleRadius * Math.Cos(j * angle));
                        int y1 = (int)(centerY + circleRadius * Math.Sin(j * angle));
                        graphics.DrawLine(Pens.Gray, x, y, x1, y1);
                    }
                }
                // Рисуем прямоугольники с текстом
                for (int i = 0; i < rectangleCount; i++)
                {
                    // Рассчитываем координаты центра прямоугольника на окружности
                    int x = (int)(centerX + circleRadius * Math.Cos(i * angle));
                    int y = (int)(centerY + circleRadius * Math.Sin(i * angle));

                    var destValues = uniqueCombinations.Where(combination => combination.Source == source[i])
                                          .Select(combination => combination.Dest);
                    // Рисуем линии между прямоугольниками
                    for (int j = 0; j < rectangleCount; j++)
                    {

                        int x1 = (int)(centerX + circleRadius * Math.Cos(j * angle));
                        int y1 = (int)(centerY + circleRadius * Math.Sin(j * angle));
                        var pen = Pens.Blue;
                        if (destValues.Contains(source[j]))
                        {
                            DrawArrow(graphics, new Point(x, y), new Point(x1, y1), 15);

                        }
                    }

                    // Рассчитываем координаты верхнего левого угла прямоугольника
                    int rectWidth = 30;
                    int rectHeight = 20;
                    int rectX = x - rectWidth / 2;
                    int rectY = y - rectHeight / 2;

                    // Рисуем прямоугольник
                    graphics.FillRectangle(Brushes.Gray, rectX, rectY, rectWidth, rectHeight);

                    // Выводим текст внутри прямоугольника
                    StringFormat format = new StringFormat();
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;
                    graphics.DrawString(source[i].ToString(), new Font("Arial", 10), Brushes.Black, new Rectangle(rectX, rectY, rectWidth, rectHeight), format);



                }

            }

            return bitmap;

            void DrawArrow(Graphics graphics, Point startPoint, Point endPoint, int radius)
            {
                float arrowSize = 10;

                float distance = (float)Math.Sqrt(Math.Pow(endPoint.X - startPoint.X, 2) + Math.Pow(endPoint.Y - startPoint.Y, 2));

                if (distance < radius)
                    return;

                var arrowAngle = (float)(Math.Atan2(endPoint.Y - startPoint.Y, endPoint.X - startPoint.X) * 180.0 / Math.PI);
                endPoint = new Point((int)(endPoint.X - radius * Math.Cos(arrowAngle * Math.PI / 180.0)),
                                     (int)(endPoint.Y - radius * Math.Sin(arrowAngle * Math.PI / 180.0)));
                graphics.DrawLine(Pens.Red, startPoint, endPoint);

                using (var brush = new SolidBrush(Color.Red))
                using (var matrix = new Matrix())
                {
                    matrix.RotateAt(arrowAngle, endPoint);
                    var arrowPoints = new PointF[]
                    {
            new PointF(endPoint.X - arrowSize, endPoint.Y - arrowSize / 2),
            new PointF(endPoint.X, endPoint.Y),
            new PointF(endPoint.X - arrowSize, endPoint.Y + arrowSize / 2),
                    };
                    matrix.TransformPoints(arrowPoints);
                    graphics.FillPolygon(brush, arrowPoints);
                }
            }
        }

    }
}



