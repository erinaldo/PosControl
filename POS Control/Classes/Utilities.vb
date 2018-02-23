Imports System.IO
Imports System.Configuration
Imports System.Text
Imports System.Data.SqlClient
Imports ConnectionSQL
Imports System.Data.SqlTypes

Module Utilities
    Dim da As New SqlDataAdapter
    Public Sub WriteToText(ByVal SForm As String, ByVal SError As String)
        Dim errorLine As String
        Dim fileName As String
        Dim directory As String
        Dim fs As FileStream
        Dim startupPath As String = ("C:\BusinessPack\PosControl\Logs")
        Try
            directory = startupPath & "\LogError" & Format(Today.Date, "yyyyMM") & "\"
            fileName = directory & Format(Today.Date, "yyyyMMdd") & ".log"
            errorLine = Format(Now, "yyyyMMdd hh:mm") & " || " & "Form:" & SForm & " Log:" & SError & vbCrLf

            If Not IO.Directory.Exists(directory) Then
                IO.Directory.CreateDirectory(directory)
            End If

            If File.Exists(fileName) = False Then
                fs = File.Create(fileName)
            Else
                fs = File.Open(fileName, FileMode.Append)
            End If

            Dim info As Byte() = New UTF8Encoding(True).GetBytes(errorLine)
            fs.Write(info, 0, info.Length)
            fs.Close()
            RemoveLines(fileName)
        Catch e As Exception
        End Try
    End Sub
    Public Sub RemoveLines(filename As String)
        Dim line As String
        Dim Input As StreamReader
        Dim ID1 As String
        Dim ID2 As String
        Dim strFile As New ArrayList
        ID1 = "The statement has been terminated."
        ID2 = "Changed database context to "
        Input = File.OpenText(filename)
        ' Loop through the file
        While Input.Peek <> -1
            ' Read the next available line
            line = Input.ReadLine
            ' Check to see if the line contains what you're looking for.
            ' If not, add it to an ArrayList
            If Not line.Contains(ID1) And Not line.Contains(ID2) Then
                ' If not, add it to an ArrayList
                strFile.Add(line)
            End If
        End While
        Input.Close()
        ' Because we want to replace the content of the file, we first
        ' need to delete it.
        If File.Exists(filename) Then
            File.Delete(filename)
        End If
        ' Create a StreamWriter object with the same filename
        Dim objWriter As New System.IO.StreamWriter(filename, True)
        ' Iterate through the ArrayList
        For Each item As String In strFile
            ' Write the current item in the ArrayList to the file.
            objWriter.WriteLine(item)
        Next
        objWriter.Flush()
        objWriter.Close()
    End Sub
    Public Function GetItemsTimeStamp(ByVal PosCode As String, ByVal con As SqlConnection) As String
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("select ItemsVersion from RtExportHist where PosCode='" & PosCode & "'", con)
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)
            Dim TStamp As String
            TStamp = IIf(IsDBNull(sqlcomm.ExecuteScalar) Or IsNothing(sqlcomm.ExecuteScalar), "", sqlcomm.ExecuteScalar)
            Return TStamp
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Public Function GetItemsBTimeStamp(ByVal PosCode As String, ByVal con As SqlConnection) As String
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("select ItemsBVersion from RtExportHist where PosCode='" & PosCode & "'", con)
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)
            Dim TStamp As String
            TStamp = IIf(IsDBNull(sqlcomm.ExecuteScalar) Or IsNothing(sqlcomm.ExecuteScalar), "", sqlcomm.ExecuteScalar)
            Return TStamp
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Public Function GetBrandsTimeStamp(ByVal PosCode As String, ByVal con As SqlConnection) As String
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("select BrandsVersion from RtExportHist where PosCode='" & PosCode & "'", con)
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)
            Dim TStamp As String
            TStamp = IIf(IsDBNull(sqlcomm.ExecuteScalar) Or IsNothing(sqlcomm.ExecuteScalar), "", sqlcomm.ExecuteScalar)
            Return TStamp
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Public Function GetPLTimeStamp(ByVal PosCode As String, ByVal con As SqlConnection) As String
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("select PriceListVersion from RtExportHist where PosCode='" & PosCode & "'", con)
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)
            Dim TStamp As String
            TStamp = IIf(IsDBNull(sqlcomm.ExecuteScalar) Or IsNothing(sqlcomm.ExecuteScalar), "", sqlcomm.ExecuteScalar)
            Return TStamp
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Public Function GetThirdTimeStamp(ByVal PosCode As String, ByVal con As SqlConnection) As String
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("select ThirdPartyVersion from RtExportHist where PosCode='" & PosCode & "'", con)
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)
            Dim TStamp As String
            TStamp = IIf(IsDBNull(sqlcomm.ExecuteScalar) Or IsNothing(sqlcomm.ExecuteScalar), "", sqlcomm.ExecuteScalar)
            Return TStamp
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Public Function GetTypesTimeStamp(ByVal PosCode As String, ByVal con As SqlConnection) As String
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("select TypesVersion from RtExportHist where PosCode='" & PosCode & "'", con)
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)
            Dim TStamp As String
            TStamp = IIf(IsDBNull(sqlcomm.ExecuteScalar) Or IsNothing(sqlcomm.ExecuteScalar), "", sqlcomm.ExecuteScalar)
            Return TStamp
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Public Function GetCategoriesTimeStamp(ByVal PosCode As String, ByVal con As SqlConnection) As String
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("select CategoriesVersion from RtExportHist where PosCode='" & PosCode & "'", con)
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)
            Dim TStamp As String
            TStamp = IIf(IsDBNull(sqlcomm.ExecuteScalar) Or IsNothing(sqlcomm.ExecuteScalar), "", sqlcomm.ExecuteScalar)
            Return TStamp
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Public Function GetMaxItemsTimeStamp(ByVal con As SqlConnection) As String
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("select max(IaStamp) from ivitema1es", con)
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)
            Dim b As Byte() = IIf(IsDBNull(sqlcomm.ExecuteScalar) Or IsNothing(sqlcomm.ExecuteScalar), "", sqlcomm.ExecuteScalar)
            Dim s = "0x" + String.Concat(Array.ConvertAll(b, Function(x) x.ToString("X2")))
            Return s
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Public Function GetMaxItemsBTimeStamp(ByVal con As SqlConnection) As String
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("select max(IbStamp) from ivitemb1es", con)
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)
            Dim b As Byte() = IIf(IsDBNull(sqlcomm.ExecuteScalar) Or IsNothing(sqlcomm.ExecuteScalar), "", sqlcomm.ExecuteScalar)
            Dim s = "0x" + String.Concat(Array.ConvertAll(b, Function(x) x.ToString("X2")))
            Return s
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Public Function GetMaxBrandTimeStamp(ByVal con As SqlConnection) As String
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("select max(BrandStamp) from IvBrand1ES", con)
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)
            Dim b As Byte() = IIf(IsDBNull(sqlcomm.ExecuteScalar) Or IsNothing(sqlcomm.ExecuteScalar), "", sqlcomm.ExecuteScalar)
            Dim s = "0x" + String.Concat(Array.ConvertAll(b, Function(x) x.ToString("X2")))
            Return s
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Public Function GetMaxTypesTimeStamp(ByVal con As SqlConnection) As String
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("select max(TypeStamp) from IvType1Es", con)
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)
            Dim b As Byte() = IIf(IsDBNull(sqlcomm.ExecuteScalar) Or IsNothing(sqlcomm.ExecuteScalar), "", sqlcomm.ExecuteScalar)
            Dim s = "0x" + String.Concat(Array.ConvertAll(b, Function(x) x.ToString("X2")))
            Return s
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Public Function GetMaxCatTimeStamp(ByVal con As SqlConnection) As String
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("select max(CatStamp) from IvCategory1ES", con)
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)
            Dim b As Byte() = IIf(IsDBNull(sqlcomm.ExecuteScalar) Or IsNothing(sqlcomm.ExecuteScalar), "", sqlcomm.ExecuteScalar)
            Dim s = "0x" + String.Concat(Array.ConvertAll(b, Function(x) x.ToString("X2")))
            Return s
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Public Sub UpdateItemsTimeStamp(ByVal TStamp As String, ByVal PosCode As String, ByVal con As SqlConnection)
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("update RtExportHist set ItemsVersion='" & TStamp & "' where PosCode='" & PosCode & "'", con)
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)
            sqlcomm.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub UpdateItemsBTimeStamp(ByVal TStamp As String, ByVal PosCode As String, ByVal con As SqlConnection)
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("update RtExportHist set ItemsBVersion='" & TStamp & "' where PosCode='" & PosCode & "'", con)
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)
            sqlcomm.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Function GetMaxPlTimeStamp(ByVal ListCode As String, ByVal con As SqlConnection) As String
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("select max(PrStamp) from IvPriceListB1Es where ListCode='" & ListCode & "'", con)
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)
            Dim b As Byte() = IIf(IsDBNull(sqlcomm.ExecuteScalar) Or IsNothing(sqlcomm.ExecuteScalar), "", sqlcomm.ExecuteScalar)
            Dim s = "0x" + String.Concat(Array.ConvertAll(b, Function(x) x.ToString("X2")))
            Return s
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Public Sub UpdatePlTimeStamp(ByVal TStamp As String, ByVal PosCode As String, ByVal con As SqlConnection)
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("update RtExportHist set PriceListVersion='" & TStamp & "' where PosCode='" & PosCode & "'", con)
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)
            sqlcomm.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Function GetMaxThirdTimeStamp(ByVal con As SqlConnection) As String
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim SqlString = " select max(ThirdStamp) from SacThirdParty st join SacThirdExtra1ES se on st.ThirdID = se.ThirdID "
            SqlString = SqlString & " where se.Stk_CustAppearInRetail = 1 "
            Dim sqlcomm As New SqlCommand(SqlString, con)
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)
            Dim b As Byte() = IIf(IsDBNull(sqlcomm.ExecuteScalar) Or IsNothing(sqlcomm.ExecuteScalar), "", sqlcomm.ExecuteScalar)
            Dim s = "0x" + String.Concat(Array.ConvertAll(b, Function(x) x.ToString("X2")))
            Return s
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Public Sub UpdateThirdTimeStamp(ByVal TStamp As String, ByVal PosCode As String, ByVal con As SqlConnection)
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("update RtExportHist set ThirdPartyVersion='" & TStamp & "' where PosCode='" & PosCode & "'", con)
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)
            sqlcomm.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub UpdateBrandTimeStamp(ByVal TStamp As String, ByVal PosCode As String, ByVal con As SqlConnection)
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("update RtExportHist set BrandsVersion='" & TStamp & "' where PosCode='" & PosCode & "'", con)
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)
            sqlcomm.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub UpdateTypesTimeStamp(ByVal TStamp As String, ByVal PosCode As String, ByVal con As SqlConnection)
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("update RtExportHist set TypesVersion='" & TStamp & "' where PosCode='" & PosCode & "'", con)
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)
            sqlcomm.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub UpdateCatsTimeStamp(ByVal TStamp As String, ByVal PosCode As String, ByVal con As SqlConnection)
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("update RtExportHist set CategoriesVersion='" & TStamp & "' where PosCode='" & PosCode & "'", con)
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)
            sqlcomm.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Module
