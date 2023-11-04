Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports LogicaNegocios.ClassHolaMundo

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class WebServiceHolaMundo
    Inherits System.Web.Services.WebService
    Dim logicHolaMundo As New LogicaNegocios.ClassHolaMundo

    '<WebMethod()> _
    'Public Function HelloWorld() As String
    '   Return "Hola a todos"
    'End Function

    '<WebMethod()>
    'Public Function holamundoDesdeClase() As String

    '    Return logicHolaMundo.HolaMundo()

    'End Function

    <WebMethod()>
    Public Function AgregarMusicoGrupo(IdGrupo As Integer, IdMusico As Integer, Instrumento As String, FechaInicio As Date, FechaFin As Date) As String

        Return logicHolaMundo.AgregarMusicoGrupo(IdGrupo, IdMusico, Instrumento, FechaInicio, FechaFin)
    End Function


    <WebMethod()>
    Public Function ObtenerMusicoGenero(IdGenero As Integer) As DataSet

        Return logicHolaMundo.ObtenerMusicoGenero(IdGenero)
    End Function

    <WebMethod()>
    Public Function ObtenerGrupoMax() As DataSet

        Return logicHolaMundo.ObtenerGrupoMax()
    End Function

    <WebMethod()>
    Public Function ObtenerDetalleGrupos(IdGrupo As Integer) As DataSet

        Return logicHolaMundo.ObtenerDetalleGrupos(IdGrupo)
    End Function

    '<WebMethod()>
    'Public Function EditarSexo(Codigo As String, Abreviatura As String) As String

    '    Return logicHolaMundo.EditarSexo(Codigo, Abreviatura)
    'End Function
End Class