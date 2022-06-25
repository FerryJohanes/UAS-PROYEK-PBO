<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeAdmin.aspx.cs" Inherits="ProyekPBO_CRUD.HomeAdmin" %>

<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="utf-8" />
        <meta http-equiv="X-UA-Compatible" content="IE=edge" />
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
        <meta name="description" content="" />
        <meta name="author" content="" />
        <title>Kos Empat Mata</title>
        <link href="https://cdn.jsdelivr.net/npm/simple-datatables@latest/dist/style.css" rel="stylesheet" />
        <link href="styles.css" rel="stylesheet" />
        <script src="https://use.fontawesome.com/releases/v6.1.0/js/all.js" crossorigin="anonymous"></script>
    </head>
    <body class="sb-nav-fixed">
        <nav class="sb-topnav navbar navbar-expand navbar-dark bg-dark">
            <!-- Navbar Brand-->
            <a class="navbar-brand ps-3" href="index.html">Admin Page</a>
            <!-- Navbar-->
            <ul class="navbar-nav ms-auto ms-md-0 me-3 me-lg-4">
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" id="navbarDropdown" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false"><i class="fas fa-user fa-fw"></i></a>
                    <ul class="dropdown-menu dropdown-menu-end" aria-labelledby="navbarDropdown">
                        <li><a class="dropdown-item" href="Login.aspx">Logout</a></li>
                    </ul>
                </li>
            </ul>
        </nav>
        <div>
            <div id="layoutSidenav_content">
                <main>
                    <div class="container-fluid px-4">
                        <h1 class="mt-4"> </h1>
                        <ol class="breadcrumb mb-4">
                            <li class="breadcrumb-item"><a href="HomeAdmin.aspx"></a></li>
                            <li class="breadcrumb-item active"></li>
                        </ol>
                        <div class="card mb-4">
                            <div class="card-header">
                                <i class="fas fa-table me-1"></i>
                                Katalog Kos 
                            </div>
                            <div class="card-body">
                                <form id="form1" runat="server">

                                    <%-- INSERT AND UPDATE --%>
                                    <table>  
                                        <tr>  
                                            <td colspan="2">  
                                                <h1>Edit Data / Tambah Data</h1>  
                                            </td>  
                                        </tr>  
                                        <tr>  
                                            <td>Nomor Kamar</td>  
                                            <td>:</td>  
                                            <td>  
                                                <asp:TextBox ID="txtNo_kamar" runat="server"></asp:TextBox>  
                                            </td>  
                                        </tr>
                                        <tr>  
                                            <td>Keterangan</td>  
                                            <td>:</td>  
                                            <td>  
                                                <asp:TextBox ID="txtKeterangan" runat="server"></asp:TextBox>  
                                            </td>  
                                        </tr>  
                                        <tr>  
                                            <td>Biaya</td>  
                                            <td>:</td>  
                                            <td>  
                                                <asp:TextBox ID="txtBiaya" runat="server"></asp:TextBox>  
                                            </td>  
                                        </tr>  
                                        <tr>  
                                            <td>Status</td>  
                                            <td>:</td>  
                                            <td>  
                                                <asp:TextBox ID="txtStatus" runat="server"></asp:TextBox>  
                                            </td>  
                                        </tr>
                                        <tr>  
                                            <td colspan="2">  
                                                <asp:Button ID="btnInsertion" runat="server" Text="Insert" OnClick="btnInsertion_Click" Style="background-color:deepskyblue" />  
                                                <%--<asp:Button ID="btnInsert" runat="server" Text="Insert" OnClick="btnInsert_Click" Style="background-color:dodgerblue" />--%>  
                                                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" Style="background-color:thistle"/>
                                                <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>  
                                            </td>  
                                        </tr>  
                                    </table>
                                    <%-- DELETION --%>
                                    <table>  
                                        <tr>  
                                            <td colspan="3">  
                                                <h1>Delete</h1>  
                                            </td>  
                                        </tr>  
                                        <tr>  
                                            <td>Nomor Kamar</td>  
                                            <td>:</td>  
                                            <td>  
                                                <asp:TextBox ID="txtDelNo_kamar" runat="server"></asp:TextBox>  
                                            </td>  
                                        </tr>  
                                        <tr >  
                                            <td colspan="3">  
                                                <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />  
                                                <asp:Label ID="lblmessage1" runat="server" ForeColor="Red"></asp:Label>  
                                            </td>  
                                        </tr>  
                                    </table>
                                </form>
                                <hr />
                                <asp:PlaceHolder ID = "PlaceHolder1" runat="server" />
                            </div>
                        </div>
                    </div>
                </main>
                <footer class="py-4 bg-light mt-auto">
                    <div class="container-fluid px-4">
                        <div class="d-flex align-items-center justify-content-between small">
                            <div class="text-muted">Copyright &copy; Your Website 2022</div>
                            <div>
                                <a href="#">Privacy Policy</a>
                                &middot;
                                <a href="#">Terms &amp; Conditions</a>
                            </div>
                        </div>
                    </div>
                </footer>
            </div>
        </div>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
        <script src="scripts.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/simple-datatables@latest" crossorigin="anonymous"></script>
        <script src="datatables-simple-demo.js"></script>
    </body>
</html>
