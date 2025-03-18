using System;
using System.Collections.Generic;
using Project_3.Classes;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DBpartijen _partijenDB = new DBpartijen();
        DBthemas _themasDB = new DBthemas();
        DBstandpunten _standpunten = new DBstandpunten();
        DBverkiezingsoorten _vsoorten = new DBverkiezingsoorten();
        DBverkiezingen _verkiezingen = new DBverkiezingen();
        DBverkiezingenpartijen _vpartijen = new DBverkiezingenpartijen();
        DBpartijstandpunt _partijstandpunt = new DBpartijstandpunt();
        public MainWindow()
        {
            InitializeComponent();
            FillDataGrid();
            
        }



        MySqlConnection _con = new MySqlConnection("Server=localhost;Database=verkiezingenprj3;Uid=root;Pwd=;");

        //Clear function
        public void clearData()
        {
           
            tbPartijenNaam.Clear();
            tbPartijenAdres.Clear();
            tbPartijenPostcode.Clear();
            tbPartijenGemeente.Clear();
            tbPartijenEmail.Clear();
            tbPartijenTelefoonnummer.Clear();
            tbThema.Clear();
            tbStandpunt.Clear();
            tbVerkiezingsoort.Clear();
            tbVerkiezingpartijenId.Clear();
            tbSearchIdPartij.Clear();
            tbSearchIdThema.Clear();
            tbSearchIdStandpunt.Clear();
            tbSearchIdSthema.Clear();
            tbSearchIdVsoort.Clear();
            tbSearchIdVerkiezing.Clear();
            tbSearchIdVSoort.Clear();
            tbVerkiezingsoortpartij.Clear();
            tbPartijstandpuntId.Clear();
            tbVPartijstandpuntId.Clear();
            tbPartijstandpuntmening.Clear();
        }


        //Fill data grid

        private void FillDataGrid()
        {
            DataTable partijen = _partijenDB.SelectPartijen();
            DataTable themas = _themasDB.SelectThemas();
            DataTable standpunten = _standpunten.SelectStandpunten();
            DataTable vsoorten = _vsoorten.SelectVsoorten();
            DataTable verkiezingen = _verkiezingen.Selectverkiezingen();
            DataTable vpartijen = _vpartijen.SelectVpartijen();
            DataTable partijstandpunt = _partijstandpunt.Partijstandpunt();
            if (partijen != null && themas != null && standpunten != null && vsoorten != null && verkiezingen != null && vpartijen != null && partijstandpunt != null)
            {
                dgPartijen.ItemsSource = partijen.DefaultView;
                dgThemas.ItemsSource = themas.DefaultView;
                dgStandpunten.ItemsSource = standpunten.DefaultView;
                dgVsoorten.ItemsSource = vsoorten.DefaultView;
                dgVerkiezingen.ItemsSource = verkiezingen.DefaultView;
                dgVpartijen.ItemsSource = vpartijen.DefaultView;
                dgPartijstandpunt.ItemsSource = partijstandpunt.DefaultView;
            }
        }
        //Clear buttons
        private void ClearPartij_Click(object sender, RoutedEventArgs e)
        {
            clearData();
            btnPartijenAdd.IsEnabled = true;
            btnPartijenUpdate.IsEnabled = false;
            btnPartijenDelete.IsEnabled = false;
        }

        private void ClearThema_Click(object sender, RoutedEventArgs e)
        {
            clearData();
            btnThemaAdd.IsEnabled = true;
            btnThemaUpdate.IsEnabled = false;
            btnThemaDelete.IsEnabled = false;
        }

        private void ClearStandpunten_Click(object sender, RoutedEventArgs e)
        {
            clearData();
            btnStandpuntAdd.IsEnabled = true;
            btnStandpuntUpdate.IsEnabled = false;
            btnStandpuntDelete.IsEnabled = false;
        }

        private void ClearVerkiezingsoorten_Click(object sender, RoutedEventArgs e)
        {
            clearData();
            btnVerkiezingsoortAdd.IsEnabled = true;
            btnVerkiezingsoortUpdate.IsEnabled = false;
            btnVerkiezingsoortDelete.IsEnabled = false;
        }

        private void ClearVerkiezingen_Click(object sender, RoutedEventArgs e)
        {
            clearData();
            btnVerkiezingAdd.IsEnabled = true;
            btnVerkiezingUpdate.IsEnabled = false;
            btnVerkiezingDelete.IsEnabled = false;
        }

        private void ClearVerkiezingpartijen_Click(object sender, RoutedEventArgs e)
        {
            clearData();
            btnVerkiezingpartijenAdd.IsEnabled = true;
            btnVerkiezingpartijenUpdate.IsEnabled = false;
            btnVerkiezingpartijenDelete.IsEnabled = false;
        }


        private void ClearPartijstandpunten_Click(object sender, RoutedEventArgs e)
        {
            clearData();
            btnPartijstandpuntAdd.IsEnabled = true;
            btnPartijstandpuntUpdate.IsEnabled = false;
            btnPartijstandpuntDelete.IsEnabled = false;
        }



        // Add buttons

        private void CreatePartij_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                    _con.Open();
                    MySqlCommand cmd = _con.CreateCommand();
                    cmd.CommandText = "INSERT INTO `partij` (partij_id, naam, adres, postcode, gemeente, emailadres, telefoonnummer) VALUES (NULL, @naam, @adres, @postcode, @gemeente, @emailadres, @telefoonnummer) ";             
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@naam", tbPartijenNaam.Text);
                    cmd.Parameters.AddWithValue("@adres", tbPartijenAdres.Text);
                    cmd.Parameters.AddWithValue("@postcode", tbPartijenPostcode.Text);
                    cmd.Parameters.AddWithValue("@gemeente", tbPartijenGemeente.Text);
                    cmd.Parameters.AddWithValue("@emailadres", tbPartijenEmail.Text);
                    cmd.Parameters.AddWithValue("@telefoonnummer", tbPartijenTelefoonnummer.Text);                    
                    cmd.ExecuteNonQuery();
                    _con.Close();
                    FillDataGrid();
                    MessageBox.Show("Sucessfully inserted", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                    clearData();
                    btnPartijenAdd.IsEnabled = false;
                    btnPartijenUpdate.IsEnabled = true;
                    btnPartijenDelete.IsEnabled = true;
                
            }
            catch (MySqlException ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        
        private void CreateThema_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _con.Open();
                MySqlCommand cmd = _con.CreateCommand();
                cmd.CommandText = "INSERT INTO `thema` (thema_id, thema) VALUES (NULL, @thema)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@thema", tbThema.Text);
                cmd.ExecuteNonQuery();
                _con.Close();
                FillDataGrid();
                MessageBox.Show("Sucessfully inserted", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                clearData();
                btnPartijenAdd.IsEnabled = false;
                btnPartijenUpdate.IsEnabled = true;
                btnPartijenDelete.IsEnabled = true;

            }
            catch (MySqlException ex)
            {

                MessageBox.Show(ex.Message);
            }

        }


        private void CreateStandpunt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _con.Open();
                MySqlCommand cmd = _con.CreateCommand();
                cmd.CommandText = "INSERT INTO `standpunt` (standpunt_id, thema_id, standpunt) VALUES (NULL, @thema, @standpunt)";  
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@thema", tbSearchIdSthema.Text);
                cmd.Parameters.AddWithValue("@standpunt", tbStandpunt.Text);
                cmd.ExecuteNonQuery();
                _con.Close();
                FillDataGrid();
                MessageBox.Show("Sucessfully inserted", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                clearData();
                btnStandpuntAdd.IsEnabled = false;
                btnStandpuntUpdate.IsEnabled = true;
                btnStandpuntDelete.IsEnabled = true;

            }
            catch (MySqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void CreateVerkiezingsoorten_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _con.Open();
                MySqlCommand cmd = _con.CreateCommand();
                cmd.CommandText = "INSERT INTO `verkiezingsoort` (verkiezingsoort_id, verkiezingsoort) VALUES (NULL, @verkiezingsoort)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@verkiezingsoort", tbVerkiezingsoort.Text);
                cmd.ExecuteNonQuery();
                _con.Close();
                FillDataGrid();
                MessageBox.Show("Sucessfully inserted", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                clearData();
                btnStandpuntAdd.IsEnabled = false;
                btnStandpuntUpdate.IsEnabled = true;
                btnStandpuntDelete.IsEnabled = true;

            }
            catch (MySqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void CreateVerkiezingen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _con.Open();
                MySqlCommand cmd = _con.CreateCommand();
                cmd.CommandText = "INSERT INTO `verkiezing` (verkiezing_id, verkiezingsoortID, datum) VALUES (NULL, @verkiezingsoortID, @datum)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@verkiezingsoortID", tbSearchIdVSoort.Text);
                cmd.Parameters.AddWithValue("@datum", dpDatum.SelectedDate);
                cmd.ExecuteNonQuery();
                _con.Close();
                FillDataGrid();
                MessageBox.Show("Sucessfully inserted", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                clearData();
                btnStandpuntAdd.IsEnabled = false;
                btnStandpuntUpdate.IsEnabled = true;
                btnStandpuntDelete.IsEnabled = true;

            }
            catch (MySqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void CreateVerkiezingpartijen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _con.Open();
                MySqlCommand cmd = _con.CreateCommand();
                cmd.CommandText = "INSERT INTO `partij_verkiezing` (Partij_id, verkiezingID) VALUES (@partijid, @verkiezingid)";               //INSERT INTO `partij_verkiezing` (`partij_id`, `verkiezingID`) VALUES ('1', '1');
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@partijid", tbVerkiezingpartijenId.Text);
                cmd.Parameters.AddWithValue("@verkiezingid", tbVerkiezingsoortpartij.Text);
                cmd.ExecuteNonQuery();
                _con.Close();
                FillDataGrid();
                MessageBox.Show("Sucessfully inserted", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                clearData();
                btnStandpuntAdd.IsEnabled = false;
                btnStandpuntUpdate.IsEnabled = true;
                btnStandpuntDelete.IsEnabled = true;

            }
            catch (MySqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        private void CreatePartijstandpunt_Click(object sender, RoutedEventArgs e)
        {

        }


        //Delete
        private void DeletePartij_Click(object sender, RoutedEventArgs e)
        {
            _con.Open();
            MySqlCommand cmd = _con.CreateCommand();
            cmd.CommandText = "DELETE FROM partij WHERE partij_id = " + tbSearchIdPartij.Text + " "; 

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Partij has been deleted", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                _con.Close();
                FillDataGrid();
                clearData();
                btnPartijenAdd.IsEnabled = true;
                btnPartijenUpdate.IsEnabled = false;
                btnPartijenDelete.IsEnabled = false;
            }
            catch (MySqlException ex)
            {

                MessageBox.Show("Not deleted" + ex.Message);
            }

        }

        private void DeleteThema_Click(object sender, RoutedEventArgs e)
        {
            _con.Open();
            MySqlCommand cmd = _con.CreateCommand();
            cmd.CommandText = "DELETE FROM thema WHERE thema_id = " + tbSearchIdThema.Text + " ";

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Partij has been deleted", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                _con.Close();
                FillDataGrid();
                clearData();
                btnThemaAdd.IsEnabled = true;
                btnThemaUpdate.IsEnabled = false;
                btnThemaDelete.IsEnabled = false;
            }
            catch (MySqlException ex)
            {

                MessageBox.Show("Not deleted" + ex.Message);
            }
        }

        private void DeleteStandpunt_Click(object sender, RoutedEventArgs e)
        {
            _con.Open();
            MySqlCommand cmd = _con.CreateCommand();
            cmd.CommandText = "DELETE FROM standpunt WHERE standpunt_id = " + tbSearchIdStandpunt.Text + " ";

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Standpunt has been deleted", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                _con.Close();
                FillDataGrid();
                clearData();
                btnStandpuntAdd.IsEnabled = true;
                btnStandpuntUpdate.IsEnabled = false;
                btnStandpuntDelete.IsEnabled = false;
            }
            catch (MySqlException ex)
            {

                MessageBox.Show("Not deleted" + ex.Message);
            }
        }

        private void DeleteVerkiezingsoorten_Click(object sender, RoutedEventArgs e)
        {
            _con.Open();
            MySqlCommand cmd = _con.CreateCommand();
            cmd.CommandText = "DELETE FROM verkiezingsoort WHERE verkiezingsoort_id = " + tbSearchIdVsoort.Text + " ";

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Standpunt has been deleted", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                _con.Close();
                FillDataGrid();
                clearData();
                btnStandpuntAdd.IsEnabled = true;
                btnStandpuntUpdate.IsEnabled = false;
                btnStandpuntDelete.IsEnabled = false;
            }
            catch (MySqlException ex)
            {

                MessageBox.Show("Not deleted" + ex.Message);
            }
        }

        private void DeleteVerkiezingen_Click(object sender, RoutedEventArgs e)
        {
            _con.Open();
            MySqlCommand cmd = _con.CreateCommand();
            cmd.CommandText = "DELETE FROM verkiezing WHERE verkiezing_id = " + tbSearchIdVerkiezing.Text + " ";

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Standpunt has been deleted", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                _con.Close();
                FillDataGrid();
                clearData();
                btnStandpuntAdd.IsEnabled = true;
                btnStandpuntUpdate.IsEnabled = false;
                btnStandpuntDelete.IsEnabled = false;
            }
            catch (MySqlException ex)
            {

                MessageBox.Show("Not deleted" + ex.Message);
            }
        }

        private void DeleteVerkiezingpartijen_Click(object sender, RoutedEventArgs e)
        {
            _con.Open();
            MySqlCommand cmd = _con.CreateCommand();
            cmd.CommandText = "DELETE FROM partij_verkiezing WHERE partij_id = " + tbVerkiezingpartijenId.Text + " ";

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Standpunt has been deleted", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                _con.Close();
                FillDataGrid();
                clearData();
                btnStandpuntAdd.IsEnabled = true;
                btnStandpuntUpdate.IsEnabled = false;
                btnStandpuntDelete.IsEnabled = false;
            }
            catch (MySqlException ex)
            {

                MessageBox.Show("Not deleted" + ex.Message);
            }
        }


        private void DeletePartijstandpunt_Click(object sender, RoutedEventArgs e)
        {

        }


        //update
        private void UpdatePartij_Click(object sender, RoutedEventArgs e)
        {
            _con.Open();
            MySqlCommand cmd = _con.CreateCommand();
            cmd.CommandText = "UPDATE partij SET naam = '" + tbPartijenNaam.Text + "', adres = '" + tbPartijenAdres.Text + "', postcode = '" + tbPartijenPostcode.Text + "', gemeente = '" + tbPartijenGemeente.Text + "', emailadres = '" + tbPartijenEmail.Text + "', telefoonnummer = '" + tbPartijenTelefoonnummer.Text + "' WHERE partij_id = '" + tbSearchIdPartij.Text + "' ";
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record has been updated sucessfully", "Updated", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (MySqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                _con.Close();
                FillDataGrid();
                clearData();
                btnPartijenAdd.IsEnabled = true;
                btnPartijenUpdate.IsEnabled = false;
                btnPartijenDelete.IsEnabled = false;
            }

        }

        private void UpdateThema_Click(object sender, RoutedEventArgs e)
        {
            _con.Open();
            MySqlCommand cmd = _con.CreateCommand();
            cmd.CommandText = "UPDATE thema SET thema = '" + tbThema.Text + "' WHERE thema_id = '" + tbSearchIdThema.Text + "' ";
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record has been updated sucessfully", "Updated", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (MySqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                _con.Close();
                FillDataGrid();
                clearData();
                btnThemaAdd.IsEnabled = true;
                btnThemaUpdate.IsEnabled = false;
                btnThemaDelete.IsEnabled = false;
            }
        }

     

        private void UpdateStandpunt_Click(object sender, RoutedEventArgs e)
        {
            

            try
            {
                _con.Open();
                MySqlCommand cmd = _con.CreateCommand();
                cmd.CommandText = "UPDATE `standpunt` SET `thema_id` = @themaId, `standpunt` = @standpunt WHERE `standpunt`.`standpunt_id` = @standpuntId;";               
                cmd.Parameters.AddWithValue("@themaId", tbSearchIdSthema.Text);
                cmd.Parameters.AddWithValue("@standpunt", tbStandpunt.Text);
                cmd.Parameters.AddWithValue("@standpuntId", tbSearchIdStandpunt.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record has been updated sucessfully", "Updated", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (MySqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                _con.Close();
                FillDataGrid();
                clearData();
                btnThemaAdd.IsEnabled = true;
                btnThemaUpdate.IsEnabled = false;
                btnThemaDelete.IsEnabled = false;
            }
        }


        private void UpdateVerkiezingsoorten_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                _con.Open();
                MySqlCommand cmd = _con.CreateCommand();
                cmd.CommandText = "UPDATE `verkiezingsoort` SET `verkiezingsoort` = @verkiezingsoort WHERE `verkiezingsoort`.`verkiezingsoort_id` = @verkiezingsoortId;";
                cmd.Parameters.AddWithValue("@verkiezingsoort", tbVerkiezingsoort.Text);
                cmd.Parameters.AddWithValue("@verkiezingsoortId", tbSearchIdVsoort.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record has been updated sucessfully", "Updated", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (MySqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                _con.Close();
                FillDataGrid();
                clearData();
                btnVerkiezingsoortAdd.IsEnabled = true;
                btnVerkiezingsoortUpdate.IsEnabled = false;
                btnVerkiezingsoortDelete.IsEnabled = false;
            }
        }

        private void UpdateVerkiezingen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _con.Open();
                MySqlCommand cmd = _con.CreateCommand();
                cmd.CommandText = "UPDATE `verkiezing` SET `verkiezingsoortID` = @verkiezingsoortID, `datum` = @datum WHERE `verkiezing_id` = @verkiezing_id;";
                cmd.Parameters.AddWithValue("@verkiezingsoortID", tbSearchIdVSoort.Text);
                cmd.Parameters.AddWithValue("@datum", dpDatum.SelectedDate);
                cmd.Parameters.AddWithValue("@verkiezing_id", tbSearchIdVerkiezing.Text);
                
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record has been updated sucessfully", "Updated", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (MySqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                _con.Close();
                FillDataGrid();
                clearData();
                btnVerkiezingsoortAdd.IsEnabled = true;
                btnVerkiezingsoortUpdate.IsEnabled = false;
                btnVerkiezingsoortDelete.IsEnabled = false;
            }
        }

        private void UpdateVerkiezingpartijen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _con.Open();
                MySqlCommand cmd = _con.CreateCommand();
                cmd.CommandText = "UPDATE `partij_verkiezing` SET `partij_id` = @partijverkiezing_id, `verkiezingID` = @verkiezingpartij_id WHERE `partij_id` = @partijverkiezing_id;";
                cmd.Parameters.AddWithValue("@partijverkiezing_id", tbVerkiezingpartijenId.Text);
                cmd.Parameters.AddWithValue("@verkiezingpartij_id", tbVerkiezingsoortpartij.Text);
               

                cmd.ExecuteNonQuery();
                MessageBox.Show("Record has been updated sucessfully", "Updated", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (MySqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                _con.Close();
                FillDataGrid();
                clearData();
                btnVerkiezingsoortAdd.IsEnabled = true;
                btnVerkiezingsoortUpdate.IsEnabled = false;
                btnVerkiezingsoortDelete.IsEnabled = false;
            }
        }

        private void UpdatePartijstandpunt_Click(object sender, RoutedEventArgs e)
        {

        }


        //quick selection
        private void dgPartijen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                tbSearchIdPartij.Text = dr["partij_id"].ToString();
                tbPartijenNaam.Text = dr["naam"].ToString();
                tbPartijenAdres.Text = dr["adres"].ToString();
                tbPartijenPostcode.Text = dr["postcode"].ToString();
                tbPartijenGemeente.Text = dr["gemeente"].ToString();
                tbPartijenEmail.Text = dr["emailadres"].ToString();
                tbPartijenTelefoonnummer.Text = dr["telefoonnummer"].ToString();  

                btnPartijenAdd.IsEnabled = false;
                btnPartijenUpdate.IsEnabled = true;
                btnPartijenDelete.IsEnabled = true;
            }
            
        }

        private void dgThemas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                tbSearchIdThema.Text = dr["thema_id"].ToString();
                tbThema.Text = dr["thema"].ToString();

                btnThemaAdd.IsEnabled = false;
                btnThemaUpdate.IsEnabled = true;
                btnThemaDelete.IsEnabled = true;
            }
        }

        private void dgStandpunten_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                tbSearchIdStandpunt.Text = dr["standpunt_id"].ToString();
                tbSearchIdSthema.Text = dr["thema_id"].ToString();      
                tbStandpunt.Text = dr["standpunt"].ToString();

                btnStandpuntAdd.IsEnabled = false;
                btnStandpuntUpdate.IsEnabled = true;
                btnStandpuntDelete.IsEnabled = true;
            }
        }

        private void dgVsoorten_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                tbSearchIdVsoort.Text = dr["verkiezingsoort_id"].ToString();
                tbVerkiezingsoort.Text = dr["verkiezingsoort"].ToString();

                btnVerkiezingsoortAdd.IsEnabled = false;
                btnVerkiezingsoortUpdate.IsEnabled = true;
                btnVerkiezingsoortDelete.IsEnabled = true;
            }
        }

        private void dgVerkiezingen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                tbSearchIdVerkiezing.Text = dr["verkiezing_id"].ToString();
                tbSearchIdVSoort.Text = dr["verkiezingsoortID"].ToString();
                dpDatum.Text = dr["datum"].ToString();

                btnVerkiezingAdd.IsEnabled = false;
                btnVerkiezingUpdate.IsEnabled = true;
                btnVerkiezingDelete.IsEnabled = true;
            }                                                            
        }

        private void dgVpartijen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                tbVerkiezingpartijenId.Text = dr["partij_id"].ToString();
                tbVerkiezingsoortpartij.Text = dr["verkiezingID"].ToString();

                btnVerkiezingpartijenAdd.IsEnabled = false;
                btnVerkiezingpartijenUpdate.IsEnabled = true;
                btnVerkiezingpartijenDelete.IsEnabled = true;
            }
        }

        private void dgPartijstandpunt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                tbPartijstandpuntId.Text = dr["partij_id"].ToString();
                tbVPartijstandpuntId.Text = dr["standpunt_id"].ToString();
                tbPartijstandpuntmening.Text = dr["mening"].ToString();

                btnPartijstandpuntAdd.IsEnabled = false;
                btnPartijstandpuntUpdate.IsEnabled = true;
                btnPartijstandpuntDelete.IsEnabled = true;
                
            }

            }
        }
}
