using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeShop.Bll;

namespace CoffeeShop
{
    public partial class CustomerUi : Form
    {

        CustomerBll _customerBll = new CustomerBll();
        public CustomerUi()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {              
                //Empty condition area
                if (String.IsNullOrEmpty(idTextBox.Text))
                {
                    MessageBox.Show("Id Can not be Empty!!!");
                    return;
                }
                if (String.IsNullOrEmpty(nameTextBox.Text))
                {
                    MessageBox.Show("Name Can not be Empty!!!");
                    return;
                }
                if (String.IsNullOrEmpty(addressTextBox.Text))
                {
                    MessageBox.Show("Address Can not be Empty!!!");
                    return;
                }
                if (String.IsNullOrEmpty(contactTextBox.Text))
                {
                    MessageBox.Show("contact Can not be Empty!!!");
                    return;
                }

                //Check UNIQUE
                if (_customerBll.IsContactExists(idTextBox.Text))
                {
                    MessageBox.Show("Id " + idTextBox.Text + " is Already Exists!");
                    return;
                }
                if (_customerBll.IsContactExists(nameTextBox.Text))
                {
                    MessageBox.Show("Name " + nameTextBox.Text + " is Already Exists!");
                    return;
                }
                if (_customerBll.IsContactExists(contactTextBox.Text))
                {
                    MessageBox.Show("Conact " + contactTextBox.Text + " is Already Exists!");
                    return;
                }


                //Add/Insert Item
                bool isAdded = _customerBll.Add(Convert.ToInt32(idTextBox.Text), nameTextBox.Text, addressTextBox.Text, Convert.ToInt32(contactTextBox.Text));

                if (isAdded)
                {
                    MessageBox.Show("Saved");
                }
                else
                {
                    MessageBox.Show("Not Saved");
                }

                //showDataGridView.DataSource = dataTable;
                showDataGridView.DataSource = _customerBll.Display();
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }


        }

        private void showButton_Click(object sender, EventArgs e)
        {
            showDataGridView.DataSource = _customerBll.Display();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
           
                //Set Id as Mandatory
                if (String.IsNullOrEmpty(idTextBox.Text))
                {
                    MessageBox.Show("Id Text Box can not be Empty!!!");
                    return;
                }

                //Delete
                if (_customerBll.Delete(Convert.ToInt32(idTextBox.Text)))
                {
                    MessageBox.Show("Deleted");
                }
                else
                {
                    MessageBox.Show("Not Deleted");
                }

                showDataGridView.DataSource =_customerBll.Display();
            

        }
     
        private void updateButton_Click_1(object sender, EventArgs e)
        {
            //Set Id as Mandatory
            if (String.IsNullOrEmpty(idTextBox.Text))
            {
                MessageBox.Show("Id Can not be Empty!!!");
                return;
            }
            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Id Can not be Empty!!!");
                return;
            }
            if (String.IsNullOrEmpty(addressTextBox.Text))
            {
                MessageBox.Show("Id Can not be Empty!!!");
                return;
            }
            if (String.IsNullOrEmpty(contactTextBox.Text))
            {
                MessageBox.Show("Contact Can not be Empty!!!");
                return;
            }
            //Check UNIQUE
            if (_customerBll.IsContactExists(contactTextBox.Text))
            {
                MessageBox.Show("Conact " + contactTextBox.Text + " is Already Exists!");
                return;
            }


            if (_customerBll.Update(Convert.ToInt32(idTextBox.Text), nameTextBox.Text, addressTextBox.Text, Convert.ToInt32(contactTextBox.Text)))
            {
                MessageBox.Show("Updated");
                showDataGridView.DataSource = _customerBll.Display();
            }
            else
            {
                MessageBox.Show("Not Updated");
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
           
            _customerBll.Search(nameTextBox.Text);
           
            
        }
    }
}
