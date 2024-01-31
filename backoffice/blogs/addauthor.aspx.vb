
Partial Class backoffice_Blogs_addauthor
    Inherits System.Web.UI.Page
    Dim Clsm As New mainclass
    Dim StrFileName As String
    Dim Str As String
    Dim Parameters As New Hashtable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
        trerror.Visible = False
        trsuccess.Visible = False
        trnotice.Visible = False
        If Not Page.IsPostBack Then

            If Val(Request.QueryString("AutId")) > 0 Then
                CKeditor2.ReadOnly = True
                Parameters.Clear()
                Parameters.Add("@AutId", Val(Request.QueryString("AutId")))
                Clsm.MoveRecord_Parameter(Me, AutId.Parent, "select * from AuthorMaster where  AutId=@AutId", Parameters)
                ' parentid.Enabled = False
                CKeditor2.ReadOnly = False
                CKeditor2.Text = Server.HtmlDecode(smalldesc.Text)


                If AutImage.Text.Trim() <> "" Then
                    File1.Visible = True
                    Image1.ImageUrl = "~/Uploads/SmallImages/" & AutImage.Text
                    LinkButton1.Visible = True
                    Image1.Visible = True
                Else
                    LinkButton1.Visible = False
                End If
            End If
        End If
    End Sub
    Function CheckImgType(ByVal fileName As String) As Boolean
        Dim ext As String = Path.GetExtension(fileName)
        Select Case ext.ToLower()
            Case ".gif"
                Return True
            Case ".png"
                Return True
            Case ".jpg"
                Return True
            Case ".jpeg"
                Return True
            Case ".bmp"
                Return True
            Case ".swf"
                Return True
            Case Else
                Return False
        End Select
    End Function
    
  

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Try
            smalldesc.Text = Server.HtmlEncode(CKeditor2.Text)
            CKeditor2.ReadOnly = True
            If Val(AutId.Text) = 0 Then
                If Path.GetFileName(File1.PostedFile.FileName) <> "" Then
                    If (CheckImgType(Path.GetFileName(File1.PostedFile.FileName))) = False Then
                        trnotice.Visible = True
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif,swf or Png'"
                        Exit Sub
                    End If
                    AutImage.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File1.PostedFile.FileName).Replace(" ", "").Replace("&", "")))
                End If
                status.Checked = True
                Dim var = Clsm.MasterSave(Me, AutId.Parent, 8, mainclass.Mode.modeAdd, "AuthorMasterSP", Server.HtmlDecode(Session("UserId")))

                If Path.GetFileName(File1.PostedFile.FileName) <> "" Then

                    Parameters.Clear()
                    Parameters.Add("@AutId", Val(var))
                    StrFileName = Clsm.SendValue_Parameter("Select AutImage from AuthorMaster where AutId=@AutId", Parameters)
                    Dim F1 As New FileInfo(Request.ServerVariables("Appl_Physical_Path") & "Uploads\SmallImages\" & StrFileName)
                    If F1.Exists Then
                        Parameters.Clear()
                        Parameters.Add("@AutId", Val(var))
                        Clsm.ExecuteQry_Parameter("delete from AuthorMaster where AutId=@AutId", Parameters)
                        trnotice.Visible = True
                        lblnotice.Text = "File already exist, Please choose another name."
                        Exit Sub
                    Else
                        File1.PostedFile.SaveAs(Request.ServerVariables("Appl_Physical_Path") & "\uploads\SmallImages\" & StrFileName)
                    End If
                End If



                Clsm.ClearallPanel(Me, AutId.Parent)
                trsuccess.Visible = True
                lblsuccess.Text = "Author added successfully."
            Else

                Dim var = Clsm.MasterSave(Me, AutId.Parent, 8, mainclass.Mode.modeModify, "AuthorMasterSP", Server.HtmlDecode(Session("UserId")))

                If Path.GetFileName(File1.PostedFile.FileName) <> "" Then
                    AutImage.Text = HttpUtility.HtmlEncode(Path.GetFileName(var & "_" & Path.GetFileName(File1.PostedFile.FileName).Replace(" ", "").Replace("&", "")))
                    Dim F1 As New FileInfo(Request.ServerVariables("Appl_Physical_Path") & "Uploads\SmallImages\" & Server.HtmlDecode(AutImage.Text))
                    If F1.Exists Then
                        trnotice.Visible = True
                        lblnotice.Text = "File already exist, Please choose another name."
                        Exit Sub
                    End If

                    Dim objcon As New SqlConnection(Clsm.strconnect)
                    objcon.Open()
                    Dim objcmd As SqlCommand = New SqlCommand("update AuthorMaster set AutImage=@AutImage where AutId=" & Val(var) & "", objcon)
                    objcmd.Parameters.Add(New SqlParameter("@AutImage", Server.HtmlDecode(AutImage.Text)))
                    objcmd.ExecuteNonQuery()
                    objcon.Close()

                    File1.PostedFile.SaveAs(Request.ServerVariables("Appl_Physical_Path") & "\uploads\SmallImages\" & Server.HtmlDecode(AutImage.Text))
                End If

                Response.Redirect("viewauthormaster.aspx?edit=edit")
            End If
            CKeditor2.ReadOnly = False

        Catch ex As Exception
            trerror.Visible = True
            lblerror.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Val(Request.QueryString("AutId")) > 0 Then
            Response.Redirect("viewauthormaster.aspx")
        End If

        Clsm.ClearallPanel(Me, AutId.Parent)
    End Sub
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        If AutImage.Text <> "" Then
            Dim F1 As New FileInfo(Request.ServerVariables("Appl_Physical_Path") & "Uploads\SmallImages\" & AutImage.Text)
            If F1.Exists Then
                F1.Delete()
            End If
        End If
        Parameters.Clear()
        Parameters.Add("@AutId", Val(Request.QueryString("AutId")))
        Clsm.ExecuteQry_Parameter("update AuthorMaster set AutImage='' where AutId=@AutId", Parameters)
        AutImage.Text = ""
        Image1.Visible = False
        trsuccess.Visible = True
        LinkButton1.Visible = False
        lblsuccess.Text = "File deleted successfully."
    End Sub


End Class
