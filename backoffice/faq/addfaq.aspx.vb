
Partial Class backoffice_faq_addfaq
    Inherits System.Web.UI.Page
    Dim clsm As New mainclass
    Dim Parameters As New Hashtable
    Dim AUserSession As HttpCookie
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.Cookies("AUserSession") Is Nothing = True Then
            AUserSession = New HttpCookie("AUserSession")
        Else
            AUserSession = Request.Cookies("AUserSession")
        End If

        trerror.Visible = False
        trsuccess.Visible = False
        trnotice.Visible = False
        If Page.IsPostBack = False Then
            If Val(Request.QueryString("cid")) <> 0 Then
                CKeditor2.ReadOnly = True
                Parameters.Clear()
                Parameters.Add("@cid", Val(Request.QueryString("cid")))
                clsm.MoveRecord_Parameter(Me, cid.Parent, "select * from FAQDetails where cid=@cid", Parameters)
                CKeditor2.ReadOnly = False
                CKeditor2.Text = Server.HtmlDecode(description.Text)
            End If
        End If
    End Sub
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Try
            description.Text = Server.HtmlEncode(CKeditor2.Text)
            CKeditor2.ReadOnly = True
            'If clsm.MasterSave(Me, cid.Parent, 6, mainclass.Mode.modeCheckDuplicate, "FAQDetailsSP", Server.HtmlDecode(Session("UserId"))) > 0 Then
            '    CKeditor2.ReadOnly = False
            '    trnotice.Visible = True
            '    lblnotice.Text = "This title already exist."
            '    Exit Sub
            'End If
            If Val(cid.Text) = 0 Then
                If Val(AUserSession("Trid")) <> 1 Then
                    status.Checked = False
                End If
                status.Checked = True
                CKeditor2.ReadOnly = True
                Dim var = clsm.MasterSave(Me, cid.Parent, 6, mainclass.Mode.modeAdd, "FAQDetailsSP", Server.HtmlDecode(Session("UserId")))
                CKeditor2.ReadOnly = False

                '***************** for log history*********************

                clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Add", Convert.ToString(question.Text), Convert.ToString(var), Convert.ToString("FAQ"), "0", "FAQ")

                '*********************** end for log history*******************************
                clsm.ClearallPanel(Me, cid.Parent)
                CKeditor2.Text = ""
                trsuccess.Visible = True
                lblsuccess.Text = "Record added successfully."
            Else
                CKeditor2.ReadOnly = True
                Dim var = clsm.MasterSave(Me, cid.Parent, 6, mainclass.Mode.modeModify, "FAQDetailsSP", Server.HtmlDecode(Session("UserId")))
                CKeditor2.ReadOnly = False
                '***************** for log history*********************

                clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Edit", Convert.ToString(question.Text), Convert.ToString(var), Convert.ToString("FAQ"), "0", "FAQ")

                '*********************** end for log history*******************************
                Response.Redirect("viewfaq.aspx?edit=edit")
            End If
        Catch ex As Exception
            trerror.Visible = True
            lblerror.Text = ex.Message
        End Try
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Val(cid.Text) = 0 Then
            clsm.ClearallPanel(Me, cid.Parent)
        Else
            Response.Redirect("viewfaq.aspx")
        End If
    End Sub

    
    

   
End Class


