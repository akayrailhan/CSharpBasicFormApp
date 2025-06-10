using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormApp
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }
        FormAppEntities db = new FormAppEntities();

        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            lblLocationCount.Text = db.Location.Count().ToString();

            lblTotalCapacity.Text = db.Location.Sum(x => x.LocationCapacity).ToString();

            lblGuideCount.Text = db.Guide.Count().ToString();

            lblAvgCapacity.Text = db.Location.Average(x => x.LocationCapacity).ToString();

            lblAverageTourPrice.Text = (db.Location.Average(x => x.LocationPrice).ToString());

            lblLastAddedCountry.Text = db.Location.OrderByDescending(x => x.LocationId).Select(y => y.LocationCountry).FirstOrDefault();

            lblBarcelonaCapacity.Text = db.Location.Where(x => x.LocationCity == "Barcelona").Select(y => y.LocationCapacity).FirstOrDefault().ToString();

            lblTurkeyAvgCapacity.Text = db.Location.Where(x => x.LocationCountry == "Türkiye").Average(x => x.LocationCapacity).ToString();
            
            lblViayanaGuide.Text = db.Location.Where(x => x.LocationCity == "Viyana").Select(y => y.Guide.GuideName + " " + y.Guide.GuideSurname).FirstOrDefault();

            lblMostCapacity.Text = db.Location.Max(x => x.LocationCapacity).ToString();

            lblMostExpensive.Text = db.Location.Where(x => x.LocationPrice == db.Location.Max(y => y.LocationPrice))
                .Select(z => z.LocationCity + " " + z.LocationCountry).FirstOrDefault();

            lblAliYilmazTourNumber.Text = db.Location
                .Where(x => x.Guide.GuideName == "Ali" && x.Guide.GuideSurname == "Yılmaz")
                .Select(y => y.LocationId).Count().ToString();


        }

    }
}
