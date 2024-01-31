
Partial Class backoffice_faq_viewfaq
    Inherits System.Web.UI.Page
    Public appno As Integer
    Public AUserSession As HttpCookie
    Dim clsm As New mainclass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        trerror.Visible = False
        trsuccess.Visible = False
        trnotice.Visible = False
        If Request.Cookies("AUserSession") Is Nothing = True Then
            AUserSession = New HttpCookie("AUserSession")
        Else
            AUserSession = Request.Cookies("AUserSession")
        End If
        If Not Page.IsPostBack Then
            Label1.Visible = False
            griddata()
            If Request.QueryString("edit") = "edit" Then
                trsuccess.Visible = True
                lblsuccess.Text = "Record Updated Successfully."

            End If
        End If
    End Sub
    Protected Sub griddata()
        Label1.Visible = False
        Dim strq2 As String
        Dim parameters As New Hashtable
        strq2 = "select * from FAQDetails where 1=1  order by displayorder"
        ' clsm.GridviewDatashow(GridView1, strq2)
        clsm.GridviewData_Parameter(GridView1, strq2, parameters)
        If GridView1.Rows.Count = 0 Then
            trnotice.Visible = True
            lblnotice.Text = "No Uploaded Banner"
            GridView1.Visible = False
        Else
            GridView1.Visible = True
        End If
        appno = GridView1.Rows.Count
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Try
            GridView1.PageIndex = e.NewPageIndex
            griddata()
        Catch ex As Exception
            Label1.Visible = True
            Label1.Text = ex.Message.ToString
        End Try
    End Sub
    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand

        If e.CommandName = "btndel" Then
            Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)

            Dim parameters As New Hashtable
            parameters.Add("@bid", Val(e.CommandArgument.ToString()))
            Dim strsql As String = "delete from FAQDetails where cid=@bid"
            clsm.ExecuteQry_Parameter(strsql, parameters)
            parameters.Clear()
            clsm.ExecuteQry_Parameter("delete from map_faq_department where faqid=" & Val(e.CommandArgument.ToString()) & "", parameters)
            clsm.ExecuteQry_Parameter("delete from map_faq_course where faqid=" & Val(e.CommandArgument.ToString()) & "", parameters)

            griddata()
            trsuccess.Visible = True
            lblsuccess.Text = "Record Deleted Successfully."
          
        End If
        If e.CommandName = "lnkstatus" Then
            Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)
            Dim lblstatus As Label = row.FindControl("lblstatus")
            If lblstatus.Text = "False" Then

                Dim parameters As New Hashtable
                parameters.Add("@bid", Val(e.CommandArgument.ToString()))
                Dim strsql As String = "update FAQDetails set status=1 where cid=@bid"
                clsm.ExecuteQry_Parameter(strsql, parameters)
            ElseIf lblstatus.Text = "True" Then

                Dim parameters As New Hashtable
                parameters.Add("@bid", Val(e.CommandArgument.ToString()))
                Dim strsql As String = "update FAQDetails set status=0 where cid=@bid"
                clsm.ExecuteQry_Parameter(strsql, parameters)
            End If
            griddata()
            trsuccess.Visible = True
            lblsuccess.Text = "Status Changed Successfully !!!"
            'Label1.Visible = True
            'Label1.Text = "Status Changed Successfully !!!"
        End If

        If e.CommandName = "btnedit" Then
            Response.Redirect("addfaq.aspx?cid=" & e.CommandArgument)
        End If
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lnkstatus As ImageButton = e.Row.FindControl("lnkstatus")
            Dim lblstatus As Label = e.Row.FindControl("lblstatus")
            'Dim imgimage As HtmlImage = e.Row.FindControl("imgimage")
            'Dim lblimage As Label = e.Row.FindControl("lblimage")
            Dim btndel As ImageButton = e.Row.FindControl("btndel")

            If lblstatus.Text = "True" Then
                lnkstatus.ImageUrl = "~/BackOffice/assets/ico_unblock.png"
                lnkstatus.ToolTip = "Active"
            ElseIf lblstatus.Text = "False" Then
                lnkstatus.ImageUrl = "~/BackOffice/assets/ico_block.png"
                lnkstatus.ToolTip = "Inactive"
            End If
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='" & Session("altColor") & "'")
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'")

            If Val(AUserSession("Trid")) <> 1 Then
                'lnkstatus.Visible = False
                'btndel.Visible = False
                'GridView1.Columns(4).Visible = False
                'GridView1.Columns(6).Visible = False
            End If


        End If
        If e.Row.RowType = DataControlRowType.DataRow Or e.Row.RowType = DataControlRowType.Header Then
            '  e.Row.Cells(5).Visible = False
        End If
    End Sub

End Class


