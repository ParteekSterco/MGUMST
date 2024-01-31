
Partial Class backoffice_encrypt
    Inherits System.Web.UI.Page
    Dim clsm As New mainclass
    Dim objEncrypt As New Enc_Decyption
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnencrypt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnencrypt.Click
        litencrypt.Text = objEncrypt.AES_Encrypt(Trim(textencrypt.Text), "@9899848281")

 
    End Sub

    Protected Sub btndecrypt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btndecrypt.Click
        litdecrypt.Text = objEncrypt.AES_Decrypt(Trim(txtdecrypt.Text), "@9899848281")
         
    End Sub
End Class
