<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Regis.aspx.cs" Inherits="ProyekPBO_CRUD.Regis" %>

<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="utf-8" />
        <meta http-equiv="X-UA-Compatible" content="IE=edge" />
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
        <meta name="description" content="" />
        <meta name="author" content="" />
        <title>Login</title>
        <link href="styles.css" rel="stylesheet" />
    </head>
    <body class="bg-info">
        <div id="layoutAuthentication">
            <div id="layoutAuthentication_content">
                <main>
                    <div class="container">
                        <div class="row justify-content-center">
                            <div class="col-lg-5">
                                <div class="card shadow-lg border-0 rounded-lg mt-5">
                                    <div class="card-header"><h3 class="text-center font-weight-light my-4">Login</h3></div>
                                    <form id="form2" runat="server">
                                    <div class="card-body">
                                            <div class="form-floating mb-3">
                                                <asp:TextBox ID="txtUsername" runat="server" class="form-control" placeholder="Username"/>
                                                <asp:RequiredFieldValidator ID="rfvUser" ErrorMessage="Please enter Username" ControlToValidate="txtusername" runat="server" />
                                                <label for="txtusername">Username</label>
                                            </div>
                                            <div class="form-floating mb-3">
                                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="form-control"/>
                                                <asp:RequiredFieldValidator ID="rfvPWD" runat="server" ControlToValidate="txtpassword" ErrorMessage="Please enter Password"/>
                                                <label for="txtpassword">Password</label>
                                            </div>
                                            <div class="form-floating mb-3">
                                                <asp:TextBox ID="txtNama" runat="server" class="form-control"/>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtnama" ErrorMessage="Please enter Password"/>
                                                <label for="txtpassword">Nama Lengkap</label>
                                            </div>
                                            <div class="form-floating mb-3">
                                                <asp:TextBox ID="txtNoTelp" runat="server" class="form-control"/>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtnotelp" ErrorMessage="Please enter Password"/>
                                                <label for="txtpassword">Nomor Telpon</label>
                                            </div>
                                            <div class="d-flex align-items-center justify-content-between mt-4 mb-0">
                                                <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="btnRegistrasi_Click" Style="background-color:cyan" />
                                            </div>
                                    </div>
                                        <div class="card-footer text-center py-3">
                                            <div class="">Sudah memiliki akun? Login <a href="Login.aspx">Disini.</a>
                                        </div>
                                    </div>
                                    </form>
                                </div>
                            </div>
                        </div>
                    </div>
                </main>
            </div>
            <div id="layoutAuthentication_footer">
                <footer class="py-4 bg-light mt-auto">
                    <div class="container-fluid px-4">
                        <div class="d-flex align-items-center justify-content-between small">
                            <div class="text-muted">Copyright &copy; Kelompok 5 Kelas G</div>
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
        <script src="js/scripts.js"></script>
    </body>
</html>