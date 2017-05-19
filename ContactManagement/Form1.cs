using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ContactManagement
{
    public partial class Form1 : Form
    {
        List<People> peopleList = new List<People>(); // storing contact card information in list
        DataTable contactcard = new DataTable();
        fileMethods file = new fileMethods();
        public Form1()
        {
            InitializeComponent();
            peopleList = file.readFile("contact.csv"); // read the contact info from the csv and fill the list
            fillView();
            initializeList();
            label3.Text = peopleList.Count.ToString(); // update the count
            
        }
        //on button click event
        private void button1_Click(object sender, EventArgs e)
        {
            //checking if the feilds are empty before inserting the contact into contact card
            if(nameBox.Text != null && nameBox.Text != "" && numberBox.Text != null && numberBox.Text != "") 
            {
                var temp = new People(nameBox.Text, numberBox.Text);
                if(peopleList.Contains(temp)) // if the contact contains
                {
                    errorLabel.Text = "* Contact already exits in the record"; // displaying error
                    errorLabel.Visible = true;
                }
                else // if contact does not exist
                { 
                    errorLabel.Visible = false;
                    peopleList.Add(new People() { Name=nameBox.Text,Number=numberBox.Text}); // adding the contact to contact card
                    label3.Text = peopleList.Count.ToString(); // update the count
                    this.fillView(); // update the list view
                    file.writeFile(peopleList, "contact.csv"); // updating the file 
                }
                nameBox.Text = "";
                numberBox.Text = "";
                

            }
            // if the feilds  are empty display the respective error message to user.
            else
            {
                errorLabel.Text = "* Enter valid Name and/or Number";
                errorLabel.Visible = true;
                nameBox.Text = "";
                numberBox.Text = "";
            }
        }
        // create headers
        public void initializeList()
        {
            contactView.View = View.Details;
            contactView.Columns.Add("Contact Name", 297);
            contactView.Columns.Add("Contact Number", 299);
        }
        //update the list view
        public void fillView()
        {
            contactView.Clear(); // clear the view
            initializeList(); // create headers
           foreach(People a in peopleList) // fill the list 
            {
                contactView.Items.Add(new ListViewItem(new String[] { a.Name,a.Number}));
            }
        }
        //delete selected contacts
        private void button2_Click(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indexes = this.contactView.SelectedIndices;
            var temp_list = new List<People>();
            foreach (int index in indexes) // store the contacts to temp list to eliminate incorrect deletion of contacts
            {
                temp_list.Add(peopleList[index]);
            }
            foreach(People a in temp_list) // remove the elements from the contact card
            {
                peopleList.Remove(a);
            }
            label3.Text = peopleList.Count.ToString(); // update the count
            fillView(); // update the view
            file.writeFile(peopleList, "contact.csv"); // updating the file 
        }
        // delete all contacts
        private void button3_Click(object sender, EventArgs e)
        {
            peopleList.Clear(); // clear the list
            fillView(); // update the view
            label3.Text = peopleList.Count.ToString(); // update the count
            file.writeFile(peopleList, "contact.csv"); // updating the file 
        }
    }
}
