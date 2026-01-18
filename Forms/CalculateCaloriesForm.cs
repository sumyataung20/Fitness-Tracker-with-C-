using System;
using System.Windows.Forms;
using FitnessTracker.Models;

namespace FitnessTracker.Forms
{
    public partial class CalculateCaloriesForm : Form
    {
        public int TotalCaloriesBurned { get; private set; }
        private User currentUser;

        public CalculateCaloriesForm(User user)
        {
            InitializeComponent(); // MUST exist in Designer
            currentUser = user;
            TotalCaloriesBurned = 0;
        }
    }
}
