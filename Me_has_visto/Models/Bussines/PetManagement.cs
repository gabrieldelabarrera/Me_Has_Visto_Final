﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;

namespace Me_has_visto.Models.Bussines
{
    public class PetManagement
    {
    }

    public static void CreateThumbnail(
    string fileName, string filePath,
    in thumbWi, int thumbHi,
    bool maintainAspect)
    {
        //no hacer nada si el tamaño
        //original es mas pequeño
        //el designado para la
        //miniatura
        var originalFile=
        Path.Combine(filePatch, fileName);
        var source =
        Image.FromFile(originalFile);
        var source =
        Image.FromFile(originalFile);
        if(source.Width <= thumbWi &&
        source.Height <= thumbHi)
        return;

        Bitmap thumbnail;
        try
        {
            int wi = thumbWi;
            int hi = thumbHi;
            if (maintainAspect)
                {
                    //mantener el aspecto a pesar
                    //de los parametros del tamaño
                    //de la vista previa
                    wi = thumbWi;
                    hi = (int)(source.Height *
                    ((decimal)thumbWi / source.Width));
                }
        else
        {
            hi = thumbHi;
            wi = (int) (source.Width *
            ((decimal)thumbHi / source.Height));
        }
    thumbnail = new Bitmap(wi, hi);
    using(Graphics g = Graphics.FromImage(thumbnail))
{
    g.InterpolaTionMode =
    InterpolationMode.HighQualityBicubic;
    g.FillRectangle(Brushes.Transparent,
    0, 0,
    wi, hi);
    g.DrawImage(source, 0, 0, wi, hi);
}
        
}
    }
}