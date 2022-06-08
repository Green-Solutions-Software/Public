using GS.Cordoba.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.Cordoba.Rest.SDK.Interfaces
{
    public interface IFilesRepository 
    {
        string Url(long id, int width, int height, PictureDisplayMode displayMode = PictureDisplayMode.Cut, ScaleMode scaleMode = ScaleMode.ProportionalBiggest, int revision = 0);
    }
}
