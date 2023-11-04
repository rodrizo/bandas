Imports Oracle.ManagedDataAccess.Client
Imports System.Configuration




Public Class ClassHolaMundo

    Dim Esquema As String = ConfigurationSettings.AppSettings("Esquema")
    Dim connString As String = ConfigurationSettings.AppSettings("Oracle")


    'Public Function HolaMundo() As String
    '    Return "Hola Mundo desde Clase de Ws"
    'End Function


    Public Function AgregarMusicoGrupo(IdGrupo As Integer, IdMusico As Integer, Instrumento As String, FechaInicio As Date, FechaFin As Date) As String


        Dim comando As New OracleCommand
        Dim parametro As New OracleParameter
        Dim tabla As New DataTable
        Dim conexion As New CapaDatos.DataConnection
        Dim salida As String

        conexion.AbrirConexion(connString)


        Try
            comando.CommandText = "pkgMain.agregar_musico_grupo"
            comando.CommandType = CommandType.StoredProcedure


            parametro = New OracleParameter
            parametro.ParameterName = "p_IdGrupo"
            parametro.Direction = ParameterDirection.Input
            conexion.GetOracleDbType(parametro, IdGrupo)
            comando.Parameters.Add(parametro)

            parametro = New OracleParameter
            parametro.ParameterName = "p_IdMusico"
            parametro.Direction = ParameterDirection.Input
            conexion.GetOracleDbType(parametro, IdMusico)
            comando.Parameters.Add(parametro)

            parametro = New OracleParameter
            parametro.ParameterName = "p_Instrumento"
            parametro.Direction = ParameterDirection.Input
            conexion.GetOracleDbType(parametro, Instrumento)
            comando.Parameters.Add(parametro)


            parametro = New OracleParameter
            parametro.ParameterName = "p_FechaInicio"
            parametro.Direction = ParameterDirection.Input
            conexion.GetOracleDbType(parametro, FechaInicio)
            comando.Parameters.Add(parametro)


            parametro = New OracleParameter
            parametro.ParameterName = "p_FechaFin"
            parametro.Direction = ParameterDirection.Input
            conexion.GetOracleDbType(parametro, FechaFin)
            comando.Parameters.Add(parametro)

            parametro = New OracleParameter
            parametro.ParameterName = "p_salida"
            parametro.Direction = ParameterDirection.Output
            parametro.OracleDbType = OracleDbType.Varchar2
            parametro.Size = 200
            comando.Parameters.Add(parametro)

            salida = conexion.DBExecuteNonQueryReturnValue(comando, "p_salida").Value
        Catch ex As Exception

        End Try
        If salida = "400" Then
            Return "El músico ya existe en este grupo."
        End If
        If salida = "1" Then
            Return "El músico se ha añadido con éxito."
        End If
        Return salida

    End Function

    Public Function ObtenerMusicoGenero(IdGenero As Integer) As DataSet


        Dim comando As New OracleCommand
        Dim parametro As New OracleParameter
        Dim tabla As New DataTable
        Dim conexion As New CapaDatos.DataConnection
        Dim dataset As New DataSet

        conexion.AbrirConexion(connString)


        Try
            comando.CommandText = "pkgMain.obtener_musico_genero"
            comando.CommandType = CommandType.StoredProcedure

            parametro = New OracleParameter
            parametro.ParameterName = "p_IdGenero"
            parametro.Direction = ParameterDirection.Input
            conexion.GetOracleDbType(parametro, IdGenero)
            comando.Parameters.Add(parametro)

            'parametro = New OracleParameter
            'parametro.ParameterName = "p_expediente_id"
            'parametro.Direction = ParameterDirection.Input
            'conexion.GetOracleDbType(parametro, valor1)
            'comando.Parameters.Add(parametro)

            parametro = New OracleParameter
            parametro.ParameterName = "p_cursor"
            parametro.Direction = ParameterDirection.Output
            parametro.OracleDbType = OracleDbType.RefCursor
            comando.Parameters.Add(parametro)

            dataset = conexion.LlenarDataSet(comando)
        Catch ex As Exception

        End Try
        Return dataset
    End Function



    Public Function ObtenerGrupoMax() As DataSet


        Dim comando As New OracleCommand
        Dim parametro As New OracleParameter
        Dim tabla As New DataTable
        Dim conexion As New CapaDatos.DataConnection
        Dim dataset As New DataSet

        conexion.AbrirConexion(connString)


        Try
            comando.CommandText = "pkgMain.obtener_grupo_max"
            comando.CommandType = CommandType.StoredProcedure

            'parametro = New OracleParameter
            'parametro.ParameterName = "p_expediente_id"
            'parametro.Direction = ParameterDirection.Input
            'conexion.GetOracleDbType(parametro, valor1)
            'comando.Parameters.Add(parametro)

            parametro = New OracleParameter
            parametro.ParameterName = "p_cursor"
            parametro.Direction = ParameterDirection.Output
            parametro.OracleDbType = OracleDbType.RefCursor
            comando.Parameters.Add(parametro)

            dataset = conexion.LlenarDataSet(comando)
        Catch ex As Exception

        End Try
        Return dataset
    End Function


    Public Function ObtenerDetalleGrupos(IdGrupo As Integer) As DataSet


        Dim comando As New OracleCommand
        Dim parametro As New OracleParameter
        Dim tabla As New DataTable
        Dim conexion As New CapaDatos.DataConnection
        Dim dataset As New DataSet

        conexion.AbrirConexion(connString)


        Try
            comando.CommandText = "pkgMain.obtener_detalle_grupos"
            comando.CommandType = CommandType.StoredProcedure

            parametro = New OracleParameter
            parametro.ParameterName = "p_IdGrupo"
            parametro.Direction = ParameterDirection.Input
            conexion.GetOracleDbType(parametro, IdGrupo)
            comando.Parameters.Add(parametro)

            'parametro = New OracleParameter
            'parametro.ParameterName = "p_expediente_id"
            'parametro.Direction = ParameterDirection.Input
            'conexion.GetOracleDbType(parametro, valor1)
            'comando.Parameters.Add(parametro)

            parametro = New OracleParameter
            parametro.ParameterName = "p_cursor"
            parametro.Direction = ParameterDirection.Output
            parametro.OracleDbType = OracleDbType.RefCursor
            comando.Parameters.Add(parametro)

            dataset = conexion.LlenarDataSet(comando)
        Catch ex As Exception

        End Try
        Return dataset
    End Function

End Class
