using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorldModels;

namespace WorldManagement
{
    public partial class World : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Continents

        protected void ListBoxContinents_SelectedIndexChanged(object sender, EventArgs e)
        {
            string continentName = (sender as ListBox).SelectedItem.Text;
            this.TextBoxContinentName.Text = continentName;
        }

        protected void ButtonUpdateContinent_Click(object sender, EventArgs e)
        {
            this.LabelContinentErrors.Text = string.Empty;

            if (string.IsNullOrWhiteSpace(this.ListBoxContinents.SelectedValue))
            {
                this.LabelContinentErrors.Text = "No continent selected.";
                return;
            }

            string newContinentName = this.TextBoxContinentName.Text.Trim();

            if (string.IsNullOrWhiteSpace(newContinentName))
            {
                this.LabelContinentErrors.Text = "No continent name specified.";
                return;
            }

            using (var context = new WorldEntities())
            {
                int continentId = int.Parse(this.ListBoxContinents.SelectedValue);
                var continent = context.Continents.FirstOrDefault(c => c.ContinentId == continentId);
                if (continent != null)
                {
                    continent.ContinentName = newContinentName;
                    context.Entry<Continent>(continent).State = EntityState.Modified;
                    context.SaveChanges();
                    Response.Redirect(Request.RawUrl);
                }
                else
                {
                    this.LabelContinentErrors.Text = "No continent found with id=" + continentId;
                }
            }
        }

        protected void ButtonAddContinent_Click(object sender, EventArgs e)
        {
            this.LabelContinentErrors.Text = string.Empty;

            string newContinentName = this.TextBoxNewContinentName.Text.Trim();

            if (string.IsNullOrWhiteSpace(newContinentName))
            {
                this.LabelContinentErrors.Text = "No continent name specified.";
                return;
            }

            using (var context = new WorldEntities())
            {
                context.Continents.Add(new Continent
                {
                    ContinentName = newContinentName
                });

                context.SaveChanges();
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void ButtonDeleteContinent_Click(object sender, EventArgs e)
        {
            this.LabelContinentErrors.Text = string.Empty;

            if (string.IsNullOrWhiteSpace(this.ListBoxContinents.SelectedValue))
            {
                this.LabelContinentErrors.Text = "No continent selected.";
                return;
            }

            string confirmValue = Request.Form["confirm-value"];
            if (confirmValue == "No")
            {
                return;
            }

            using (var context = new WorldEntities())
            {
                int continentId = int.Parse(this.ListBoxContinents.SelectedValue);
                var continent = context.Continents.FirstOrDefault(c => c.ContinentId == continentId);
                if (continent != null)
                {
                    context.Continents.Remove(continent);
                    context.SaveChanges();
                    Response.Redirect(Request.RawUrl);
                }
                else
                {
                    this.LabelContinentErrors.Text = "No continent found with id=" + continentId;
                }
            }
        }

        #endregion

        #region Countries

        protected void GridViewCountries_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState != DataControlRowState.Edit)
            {
                //In this sample, there are  3 buttons and the second one is Delete button, that's why we use the index 2
                //indexing goes as 0 is button #1, 1 Literal (Space between buttons), 2 button #2, 3 Literal (Space) etc.
                ((LinkButton)e.Row.Cells[0].Controls[2]).OnClientClick = "Confirm()";
            }
        }

        protected void GridViewCountries_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string confirmValue = Request.Form["confirm-value"];
            if (confirmValue == "No")
            {
                e.Cancel = true;
            }
        }

        protected void GridViewCountries_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            WorldEntities context = null;
            this.LabelCountryErrors.Text = string.Empty;

            try
            {
                string countryName = (this.GridViewCountries.Rows[e.RowIndex].FindControl("TextBoxCountryName") as TextBox).Text;
                this.ValidateName(countryName);

                float latitude;
                string latitudeAsString = (this.GridViewCountries.Rows[e.RowIndex].FindControl("TextBoxLatitude") as TextBox).Text;
                this.ValidateGeoCoordinate(latitudeAsString, out latitude);

                float longitude;
                string longitudeAsString = (this.GridViewCountries.Rows[e.RowIndex].FindControl("TextBoxLongitude") as TextBox).Text;
                this.ValidateGeoCoordinate(longitudeAsString, out longitude);

                float area;
                string areaAsString = (this.GridViewCountries.Rows[e.RowIndex].FindControl("TextBoxSurfaceArea") as TextBox).Text;
                this.ValidateArea(areaAsString, out area);

                int population;
                string populationAsString = (this.GridViewCountries.Rows[e.RowIndex].FindControl("TextBoxPopulation") as TextBox).Text;
                this.ValidatePopulation(populationAsString, out population);

                context = new WorldEntities();

                string selectedCountryId = this.GridViewCountries.DataKeys[e.RowIndex].Value.ToString();

                var country = context.Countries.FirstOrDefault(c => c.CountryId == selectedCountryId);
                if (country != null)
                {
                    var postedFile = (this.GridViewCountries.Rows[e.RowIndex].FindControl("FileUploadChangeFlag") as FileUpload).PostedFile;

                    if (postedFile != null && postedFile.ContentLength > 0)
                    {
                        byte[] data = this.GetUploadedFile(postedFile);

                        country.FlagImage = data;

                        context.Entry<Country>(country).State = EntityState.Modified;

                        context.SaveChanges();
                    }

                    country.Languages.Clear();

                    string newLanguageNames = this.GetTextBoxText(this.GridViewCountries, e.RowIndex, "TextBoxLanguages");
                    string[] languageNames = newLanguageNames.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string languageName in languageNames)
                    {
                        var language = context.Languages.FirstOrDefault(l => string.Compare(l.LanguageName, languageName, true) == 0);
                        if (language == null)
                        {
                            language = new Language
                            {
                                LanguageName = languageName
                            };

                            context.Languages.Add(language);
                            context.SaveChanges();
                        }

                        country.Languages.Add(language);
                    }

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                this.LabelCountryErrors.Text = ex.Message;
                e.Cancel = true;
            }
            finally
            {
                if (context != null)
                {
                    context.Dispose();
                }
            }
        }

        protected void GridViewCountries_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void ButtonAddCountry_Click(object sender, EventArgs e)
        {
            WorldEntities context = null;
            this.LabelCountryErrors.Text = string.Empty;

            try
            {
                string countryId = this.GetFooterRowTextBoxText(this.GridViewCountries, "TextBoxNewCountryId");
                this.ValidateCountryId(countryId);

                string countryName = this.GetFooterRowTextBoxText(this.GridViewCountries, "TextBoxNewCountryName");
                this.ValidateName(countryName);

                float latitude;
                string latitudeAsString = this.GetFooterRowTextBoxText(this.GridViewCountries, "TextBoxNewLatitude");
                this.ValidateGeoCoordinate(latitudeAsString, out latitude);

                float longitude;
                string longitudeAsString = this.GetFooterRowTextBoxText(this.GridViewCountries, "TextBoxNewLongitude");
                this.ValidateGeoCoordinate(longitudeAsString, out longitude);

                float area;
                string areaAsString = this.GetFooterRowTextBoxText(this.GridViewCountries, "TextBoxNewSurfaceArea");
                this.ValidateArea(areaAsString, out area);

                int population;
                string populationAsString = this.GetFooterRowTextBoxText(this.GridViewCountries, "TextBoxNewPopulation");
                this.ValidatePopulation(populationAsString, out population);

                context = new WorldEntities();

                int continentId = int.Parse(this.ListBoxContinents.SelectedValue);

                FileUpload flagImageUpload = this.GetFooterRowControl(this.GridViewCountries, "FileUploadNewCountryFlag") as FileUpload;
                byte[] fileData = this.GetUploadedFile(flagImageUpload.PostedFile);

                var country = new Country
                {
                    CountryId = countryId,
                    CountryName = countryName,
                    Latitude = latitude,
                    Longitude = longitude,
                    SurfaceArea = area,
                    ContinentId = continentId,
                    Population = population,
                    FlagImage = fileData
                };

                string newLanguageNames = this.GetFooterRowTextBoxText(this.GridViewCountries, "TextBoxNewLanguages");
                string[] languageNames = newLanguageNames.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string languageName in languageNames)
                {
                    var language = context.Languages.FirstOrDefault(l => string.Compare(l.LanguageName, languageName, true) == 0);
                    if (language == null)
                    {
                        language = new Language
                        {
                            LanguageName = languageName
                        };

                        context.Languages.Add(language);
                        context.SaveChanges();
                    }

                    country.Languages.Add(language);
                }

                context.Countries.Add(country);

                context.SaveChanges();
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception ex)
            {
                this.LabelCountryErrors.Text = ex.Message;
            }
            finally
            {
                if (context != null)
                {
                    context.Dispose();
                }
            }
        }

        private void ValidateCountryId(string countryId)
        {
            if (string.IsNullOrWhiteSpace(countryId))
            {
                throw new ArgumentException("Missing country id.");
            }

            if (countryId.Length != 3)
            {
                throw new ArgumentException("Country id should be exactly 3 chars long.");
            }
        }

        private void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Missing name.");
            }
        }

        private void ValidateGeoCoordinate(string s, out float result)
        {
            if (!float.TryParse(s, out result))
            {
                throw new ArgumentException("Geo coordinate should be a real number.");
            }
        }

        private void ValidateArea(string s, out float result)
        {
            if (!float.TryParse(s, out result) || result <= 0.0f)
            {
                throw new ArgumentException("The area should be a positive real number.");
            }
        }

        private void ValidatePopulation(string s, out int result)
        {
            if (!int.TryParse(s, out result) || result <= 0)
            {
                throw new ArgumentException("The population should be a positive integer.");
            }
        }

        private byte[] GetUploadedFile(HttpPostedFile postedFile)
        {
            if (postedFile != null)
            {
                //Create byte Array with file len
                byte[] data = new Byte[postedFile.ContentLength];

                //force the control to load data in array
                postedFile.InputStream.Read(data, 0, postedFile.ContentLength);

                return data;
            }

            return null;
        }

        #endregion

        #region Cities

        protected void ListViewCities_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            this.LabelCityErrors.Text = string.Empty;

            try
            {
                string cityName = (e.Item.FindControl("CityNameTextBox") as TextBox).Text;
                this.ValidateName(cityName);

                float latitude;
                string latitudeAsString = (e.Item.FindControl("LatitudeTextBox") as TextBox).Text;
                this.ValidateGeoCoordinate(latitudeAsString, out latitude);

                float longitude;
                string longitudeAsString = (e.Item.FindControl("LongitudeTextBox") as TextBox).Text;
                this.ValidateGeoCoordinate(longitudeAsString, out longitude);

                int population;
                string populationAsString = (e.Item.FindControl("PopulationTextBox") as TextBox).Text;
                this.ValidatePopulation(populationAsString, out population);

                var countryId = this.GridViewCountries.SelectedDataKey.Value.ToString();

                this.EntityDataSourceCities.InsertParameters.Add("CountryId", TypeCode.String, countryId);

                this.ListViewCities.DataBind();
            }
            catch (Exception ex)
            {
                this.LabelCityErrors.Text = ex.Message;
                e.Cancel = true;
            }
        }

        protected void ListViewCities_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            this.LabelCityErrors.Text = string.Empty;

            try
            {
                string cityName = (this.ListViewCities.Items[e.ItemIndex].FindControl("CityNameTextBox") as TextBox).Text;
                this.ValidateName(cityName);

                float latitude;
                string latitudeAsString = (this.ListViewCities.Items[e.ItemIndex].FindControl("LatitudeTextBox") as TextBox).Text;
                this.ValidateGeoCoordinate(latitudeAsString, out latitude);

                float longitude;
                string longitudeAsString = (this.ListViewCities.Items[e.ItemIndex].FindControl("LongitudeTextBox") as TextBox).Text;
                this.ValidateGeoCoordinate(longitudeAsString, out longitude);

                int population;
                string populationAsString = (this.ListViewCities.Items[e.ItemIndex].FindControl("PopulationTextBox") as TextBox).Text;
                this.ValidatePopulation(populationAsString, out population);
            }
            catch (DbEntityValidationException ex)
            {
                var errors = ex.EntityValidationErrors
                    .SelectMany(eve => eve.ValidationErrors)
                    .Select(ve => ve.ErrorMessage);
                this.LabelCityErrors.Text = string.Join(", ", errors);
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                this.LabelCityErrors.Text = ex.Message;
                e.Cancel = true;
            }
        }

        protected void ListViewCities_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            string confirmValue = Request.Form["confirm-value"];

            if (confirmValue == "No")
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region Common

        private string GetTextBoxText(GridView gridView, int rowIndex, string controlId)
        {
            return (gridView.Rows[rowIndex].FindControl(controlId) as TextBox).Text.Trim();
        }
        private string GetFooterRowTextBoxText(GridView gridView, string controlId)
        {
            return (gridView.FooterRow.FindControl(controlId) as TextBox).Text.Trim();
        }

        private Control GetFooterRowControl(GridView gridView, string controlId)
        {
            return gridView.FooterRow.FindControl(controlId);
        }

        #endregion
    }
}