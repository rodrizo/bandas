
Imports Oracle.ManagedDataAccess.Client

Public Class DataConnection

    Private Conexion As OracleConnection
    Private ConnectionString As String

    Public Sub AbrirConexion(ByVal strConexion As String)
        Try
            ConnectionString = strConexion
            Conexion = New OracleConnection(strConexion)
            Conexion.Open()
        Catch
            Conexion = Nothing
            Throw

        End Try
    End Sub

    Public Sub CerrarConexion()
        Try
            Conexion.Close()
        Catch ex As Exception
            Conexion.Close()
        End Try
    End Sub



    Public Function DBExecuteNonQueryReturnValue(objOracleCommand As OracleCommand, pstrReturnValue As String) As Object
        Dim ComandoOracle As OracleCommand
        Dim lobjReturnValueObject As Object = Nothing

        Try
            ComandoOracle = objOracleCommand
            ComandoOracle.Connection = Conexion
            ComandoOracle.ExecuteNonQuery()

        Catch ex As Exception

            Throw ex

        End Try

        If Not String.IsNullOrEmpty(pstrReturnValue) Then
            lobjReturnValueObject = ComandoOracle.Parameters(pstrReturnValue).Value
        End If

        Return lobjReturnValueObject
    End Function



    Public Function GetOracleDbType(ByRef pobjOracleParameter As OracleParameter, valor As Object) As Boolean
        Dim repspuesta As Boolean = True
        Dim lobjOracleDbType As OracleDbType = OracleDbType.Varchar2

        Try

            If TypeOf valor Is DateTime Then
                lobjOracleDbType = OracleDbType.Date
            End If

            If TypeOf valor Is Int64 Then
                lobjOracleDbType = OracleDbType.Int64
            End If

            If TypeOf valor Is Int32 Then
                lobjOracleDbType = OracleDbType.Int32
            End If

            If TypeOf valor Is Int16 Then
                lobjOracleDbType = OracleDbType.Int16
            End If

            If TypeOf valor Is SByte Then
                lobjOracleDbType = OracleDbType.Byte
            End If

            If TypeOf valor Is Byte Then
                lobjOracleDbType = OracleDbType.Int16
            End If

            If TypeOf valor Is Decimal Then
                lobjOracleDbType = OracleDbType.Decimal
            End If

            If TypeOf valor Is Single Then
                lobjOracleDbType = OracleDbType.Single
            End If

            If TypeOf valor Is Double Then
                lobjOracleDbType = OracleDbType.Double
            End If

            If TypeOf valor Is Byte() Then
                lobjOracleDbType = OracleDbType.Blob
            End If

            pobjOracleParameter.OracleDbType = lobjOracleDbType
            pobjOracleParameter.Value = valor
        Catch
            repspuesta = False
        End Try

        Return repspuesta
    End Function


    Public Function LlenarTabla(pobjOracleCommand As OracleCommand) As DataTable
        Dim lobjOracleCommand As OracleCommand
        Dim Tabla As New DataTable
        Dim lobjDataAdapter As OracleDataAdapter

        Try
            lobjOracleCommand = pobjOracleCommand
            lobjOracleCommand.Connection = Conexion
            lobjDataAdapter = New OracleDataAdapter(pobjOracleCommand)
            lobjDataAdapter.Fill(Tabla)
            Return Tabla
        Catch
            Throw
        End Try
    End Function


    Public Function LlenarDataSet(pobjOracleCommand As OracleCommand) As DataSet
        Dim lobjOracleCommand As OracleCommand
        Dim lobjDataSet As New DataSet
        Dim lobjDataAdapter As OracleDataAdapter

        Try
            lobjOracleCommand = pobjOracleCommand
            lobjOracleCommand.Connection = Conexion
            lobjDataAdapter = New OracleDataAdapter(pobjOracleCommand)
            lobjDataAdapter.Fill(lobjDataSet)
            Return lobjDataSet
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
