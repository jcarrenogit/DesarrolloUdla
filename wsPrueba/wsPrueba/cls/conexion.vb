Imports System.Data.SqlClient

Public Class conexion

    Private _cnnString, _host, _db, _uid, _pwd As String
    Private _cn As New SqlConnection
    Private _cm As New SqlCommand
    Private _da As New SqlDataAdapter
    Private _dt As New DataTable
    Public _strSQL As String


    Public Sub New()

    End Sub


    Public Function Conectar() As SqlConnection

        Try
            '_cn.ConnectionString = "Server=r0b;Database=cat_servicios;User Id=sa;Password=rob_1982;"
            _cn.ConnectionString = "Server=JJCARREÑO-PC;Database=cat_servicios;Trusted_Connection=True;"
            If _cn.State = ConnectionState.Open Then
                Return _cn
            Else
                _cn.Open()
                Return _cn
            End If
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Sub Desconectar()
        If _cn.State = ConnectionState.Open Then
            _cn.Close()
        End If
    End Sub

    Public Function __select() As DataTable
        Try
            _cm = New SqlCommand
            _cm.CommandText = Me._strSQL
            _cm.Connection = _cn
            _cm.CommandTimeout = 0
            _cm.CommandType = CommandType.Text

            _da = New SqlDataAdapter(_cm)
            _da.Fill(_dt)

            Return _dt

        Catch ex As Exception
            _dt = Nothing
            Return _dt
        Finally
            _da = Nothing
            _cm = Nothing
            Me.Desconectar()
        End Try

    End Function

    Public Function __insert() As Boolean
        Try
            _cm = New SqlCommand
            _cm.CommandText = Me._strSQL
            _cm.Connection = _cn
            _cm.CommandType = CommandType.Text

            _cm.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Return False
        Finally
            _cm = Nothing
            Me.Desconectar()
        End Try

    End Function

    Public Function __update() As Boolean
        Try
            _cm = New SqlCommand
            _cm.CommandText = Me._strSQL
            _cm.Connection = _cn
            _cm.CommandType = CommandType.Text

            _cm.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Return False
        Finally
            _cm = Nothing
            Me.Desconectar()
        End Try

    End Function

End Class
