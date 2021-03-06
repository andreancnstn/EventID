﻿using EventID.Model;
using EventID.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EventID.View
{
    public partial class ViewProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = 44256;
                List<Model.Image> productImage = ImageRepo.getImage();
                var image = from j in productImage
                            where j.ProductID == id
                            select new
                            {
                                j.ImageName
                            };
                rptrProductImages.DataSource = image;
                rptrProductImages.DataBind();
                List<Product> product = ProductRepo.getProduct();
                var filter = from k in product
                             where k.ProductID == id
                             select new
                             {
                                 k.ProductName,
                                 k.Price,
                                 k.Description
                             };
                rptrProducts.DataSource = filter;
                rptrProducts.DataBind();
            }
        }

        protected void btnCart_Click(object sender, EventArgs e)
        {
            int id = 44260;
            CartRepo.insertCart(id, 1);
            Response.Redirect("Cart.aspx");
        }
    }
}