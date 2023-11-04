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

    Public Function ObtenerProductos(ProveedorId As Integer) As DataSet


        Dim comando As New OracleCommand
        Dim parametro As New OracleParameter
        Dim tabla As New DataTable
        Dim conexion As New CapaDatos.DataConnection
        Dim dataset As New DataSet

        conexion.AbrirConexion(connString)


        Try
            comando.CommandText = "PAQUETE1.obtener_productos"
            comando.CommandType = CommandType.StoredProcedure

            parametro = New OracleParameter
            parametro.ParameterName = "p_proveedorId"
            parametro.Direction = ParameterDirection.Input
            conexion.GetOracleDbType(parametro, ProveedorId)
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



    Public Function ObtenerCategorias() As DataSet


        Dim comando As New OracleCommand
        Dim parametro As New OracleParameter
        Dim tabla As New DataTable
        Dim conexion As New CapaDatos.DataConnection
        Dim dataset As New DataSet

        conexion.AbrirConexion(connString)


        Try
            comando.CommandText = "PAQUETE1.obtener_categorias"
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


    Public Function ObtenerClientes(ProductoId As Integer) As DataSet


        Dim comando As New OracleCommand
        Dim parametro As New OracleParameter
        Dim tabla As New DataTable
        Dim conexion As New CapaDatos.DataConnection
        Dim dataset As New DataSet

        conexion.AbrirConexion(connString)


        Try
            comando.CommandText = "PAQUETE1.obtener_clientes"
            comando.CommandType = CommandType.StoredProcedure

            parametro = New OracleParameter
            parametro.ParameterName = "p_productoId"
            parametro.Direction = ParameterDirection.Input
            conexion.GetOracleDbType(parametro, ProductoId)
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

    'Public Function EditarSexo(Codigo As String, Abreviatura As String) As String


    '    Dim comando As New OracleCommand
    '    Dim parametro As New OracleParameter
    '    Dim tabla As New DataTable
    '    Dim conexion As New CapaDatos.DataConnection
    '    Dim salida As String

    '    conexion.AbrirConexion(connString)


    '    Try
    '        comando.CommandText = "PAQUETE1.editar_catalogo_sexos"
    '        comando.CommandType = CommandType.StoredProcedure


    '        parametro = New OracleParameter
    '        parametro.ParameterName = "p_codigo"
    '        parametro.Direction = ParameterDirection.Input
    '        conexion.GetOracleDbType(parametro, Codigo)
    '        comando.Parameters.Add(parametro)

    '        parametro = New OracleParameter
    '        parametro.ParameterName = "p_abreviatura"
    '        parametro.Direction = ParameterDirection.Input
    '        conexion.GetOracleDbType(parametro, Abreviatura)
    '        comando.Parameters.Add(parametro)

    '        parametro = New OracleParameter
    '        parametro.ParameterName = "p_salida"
    '        parametro.Direction = ParameterDirection.Output
    '        parametro.OracleDbType = OracleDbType.Varchar2
    '        parametro.Size = 200
    '        comando.Parameters.Add(parametro)

    '        salida = conexion.DBExecuteNonQueryReturnValue(comando, "p_salida").Value
    '    Catch ex As Exception

    '    End Try
    '    Return salida

    'End Function

End Class
