using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace babyfoot
{
    class ClassJoueur
    {
        private int positionX;
        private int positionY;
        private int directionX;
        private int directionY;
        private int largeur;
        private int longueur;
        private int centreX;
        private int centreY;
        private PictureBox images;
        PictureBox centre;
        PictureBox attaquant;
        PictureBox gardien;
        PictureBox defense;

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

        public int Largeur
        {
            get { return largeur; }
            set { largeur = value; }
        }

        public int Longueur
        {
            get { return longueur; }
            set { longueur = value; }
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

        public PictureBox Images
        {
            get { return images; }
            set { images = value; }
        }

        public ClassJoueur(int positionX, int positionY, int directionX, int directionY, int largeur, int longueur)
        {
            this.positionX = positionX;
            this.positionY = positionY;
            this.directionX = directionX;
            this.directionY = directionY;
            this.largeur = largeur;
            this.longueur = longueur;
        }

        public ClassJoueur(PictureBox picture)
        {
            this.images = picture;
            this.longueur = picture.Width;
            this.largeur = picture.Height;
            Point location = picture.Location;
            this.positionX = location.X;
            this.positionY = location.Y;
            this.centreX = this.positionX + this.Largeur / 2;
            this.centreY = this.positionY + this.Longueur / 2;
            this.directionX = 50;
            this.directionY = 50;
        }
    }
}
