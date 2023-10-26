using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace babyfoot
{
    class ClassBalle
    {
        private PictureBox images;
        private int positionX;
        private int positionY;
        private int directionX;
        private int directionY;
        private int largeur;
        private int longueur;
        private int vitesse;
        private int centreX;
        private int centreY;

        public int PositionX
        {
            get { return positionX; }
            set { positionX = value; }
        }

        public int PositionY
        {
            get { return positionY; }
            set { positionY = value; }
        }

        public int DirectionX
        {
            get { return directionX; }
            set { directionX = value; }
        }

        public int DirectionY
        {
            get { return directionY; }
            set { directionY = value; }
        }

        public int Longueur
        {
            get { return longueur; }
            set { longueur = value; }
        }

        public int Largeur
        {
            get { return largeur; }
            set { largeur = value; }
        }

        public int Vitesse
        {
            get { return vitesse; }
            set { vitesse = value; }
        }

        public int CentreX
        {
            get { return centreX; }
            set { centreX = value; }
        }

        public int CentreY
        {
            get { return centreY; }
            set { centreY = value; }
        }

        public ClassBalle(int positionX, int positionY, int directionX, int directionY, int largeur, int longueur, int vitesse)
        {
            this.positionX = positionX;
            this.positionY = positionY;
            this.directionX = directionX;
            this.directionY = directionY;
            this.largeur = largeur;
            this.longueur = longueur;
            this.vitesse = vitesse;
        }

        public ClassBalle(PictureBox thisimage)
        {
            this.images = thisimage;
            this.longueur = thisimage.Width;
            this.largeur = thisimage.Height;
            Point location = thisimage.Location;
            this.positionX = location.X;
            this.positionY = location.Y;
            this.centreX = this.positionX + this.Largeur / 2;
            this.centreY = this.positionY + this.Longueur / 2;
        }
    }
}
