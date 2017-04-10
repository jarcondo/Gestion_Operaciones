<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsumoMaterial.aspx.cs" Inherits="Intranet.Web.Sistema.Modulos.ProduccionServicios.Procesos.ConsumoMateriales.ConsumoMaterial" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Import Namespace="System.Xml" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title> 
	<link rel="stylesheet" type="text/css" href="../../../../../Libreria/Estilos/global.css" />
	<style type="text/css">
		
        .nuevo {
            background-image: url(../../../../../Libreria/Imagenes/new.png) !important;
        }
        .guardar {
            background-image: url(../../../../../Libreria/Imagenes/save.png) !important;
        }
        .cancelar {
            background-image: url(../../../../../Libreria/Imagenes/cancel.png) !important;
        }
        
        .subactividad {
            background-image: url(../../../../../Libreria/Imagenes/job.png) !important;
        } 
        .materiales {
            background-image: url(../../../../../Libreria/Imagenes/tools.png) !important;
        }
        .trabajocomplementario {
            background-image: url(../../../../../Libreria/Imagenes/job2.png) !important;
        }
        .imprimir{
            background-image: url(../../../../../Libreria/Imagenes/printer.png) !important;
        }
        .buscar{
            background-image: url(../../../../../Libreria/Imagenes/search.png) !important;
        }
    </style>
	<script type="text/javascript">
		// this "setGroupStyle" function is called when the GroupingView is refreshed.     
		var setGroupStyle = function (view) {
			// get an instance of the Groups
			var groups = view.getGroups();

			for (var i = 0; i < groups.length; i++) {
				var spans = Ext.query("span", groups[i]);

				if (spans && spans.length > 0) {
					// Loop through the Groups, the do a query to find the <span> with our ColorCode
					// Get the "id" from the <span> and split on the "-", the second array item should be our ColorCode
					var color = "#" + spans[0].id.split("-")[1];

					// Set the "background-color" of the original Group node.
					Ext.get(groups[i]).setStyle("background-color", "FEFEFE");
				}
			}
		};
    </script>
	<script type="text/javascript">
		var DistritoRenderer = function (value) {
			if (!Ext.isEmpty(value)) {
				return value.Distrito;
			}
			return value;
		};

		var ActividadRenderer = function (value) {
			if (!Ext.isEmpty(value)) {
				return value.Descripcion1 + ' - ' + value.Descripcion2;
			}
			return value;
		};

		var SubActividadRenderer = function (value) {
			if (!Ext.isEmpty(value)) {
				return value.DescripcionSubActividad1;
			}
			return value;
		};

		var prepareToolbar = function (grid, toolbar, rowIndex, record) {
			if (record.get("SGIO") == true) {
				//hide separator
				//toolbar.items.itemAt(1).hide();
				//hide edit button
				//toolbar.items.itemAt(2).hide();
				//toolbar.items.itemAt(0).hide();
			} else {
				//otherwise add another button
				toolbar.add(new Ext.Button({
					iconCls: "icon-accept",
					command: "accept"
				}));
				toolbar.doLayout();
			}
		};

		var ManejoConsumo = function (command, tipo, id,unidad) {
			Ext.net.DirectMethods.ManejarConsumo(command, tipo, id,unidad);

};


var EliminarSGICargo = function (command,sgi) {
    Ext.net.DirectMethods.EliminaSGICargo(command,sgi);


};

        var enterKeyPressHandler = function (f, e) {
            if (e.getKey () == e.ENTER) {
                Ext.net.DirectMethods.btnSubActAgregar_Click();
                e.stopEvent ();
            }
        }

        var enterKeyPressHandler2 = function (f, e) {
            if (e.getKey() == e.ENTER) {
                Ext.net.DirectMethods.btnMaterialAgregar_Click();
                e.stopEvent();
            }
        }

        var enterKeyPressHandler3 = function (f, e) {
            if (e.getKey() == e.ENTER) {
                Ext.net.DirectMethods.btnTCAgregar_Click();
                e.stopEvent();
            }
        }

        var AgregaMaterial = function () {
            //Ext.getCmp('ddlMaterialDescripcion').focus();
            Ext.net.DirectMethods.AgregarMaterial();
        }


        var CargarMaterial = function (unidad, precio) {
            Ext.get('txtMaterialUnidad').dom.value = unidad;
            Ext.get('txtMaterialPrecio').dom.value = precio;
            Ext.getCmp('txtMaterialCantidad').focus(true, 10);
        }

        var CargarUnidad = function (unidad, precio) {
            Ext.get('txtSubActUnidad').dom.value = unidad;
            Ext.get('txtSubActPrecio').dom.value = precio;
            Ext.getCmp('txtSubActCantidad').focus(true, 10);
        }

        var CargarTC = function (unidad, precio) {
            Ext.get('txtTCUnidad').dom.value = unidad;
            Ext.get('txtTCPrecio').dom.value = precio;
            Ext.getCmp('txtTCCantidad').focus(true, 10);
        }

        var ManejarCuadrillaTC = function () {
            var CheckCuadrillaTC = Ext.getCmp('rCuadrilla').getValue();
            if (CheckCuadrillaTC == true) {
                Ext.getCmp('ddlTCCuadrilla').show();
            } else {
                Ext.getCmp('ddlTCCuadrilla').hide();
            }
        }

        var ManejarProveedorTC = function () {
            var CheckProveedorTC = Ext.getCmp('rProveedor').getValue();
            if (CheckProveedorTC == true) {
                Ext.getCmp('ddlTCProveedor').show();
            } else {
                Ext.getCmp('ddlTCProveedor').hide();
            }
        }
	</script>
 <%-- Script Bryan--%>
   <%-- ActD--%>
    <script type="text/javascript">
         var onKeyUp = function () {
             var me = this,
                v = me.getValue(),
                field;
         };

         //           var CargarTxtBox= function() {
         //             Ext.get('idLimpieza').dom.value = StoreLlenarCajasLimpieza.get("idLimpieza");
         //             alert(Ext.get('idLimpieza').dom.value);
         //         }

         var alerta = function () {
             var record = GridPanel5.getSelectionModel().getSelected();
             //alert(record.data['buzon']);
             var buz = record.data['buzon'];
             var cuerpo = record.data['cuerpo'];
             var emboq = record.data['emboquillado'];
             var idBuz = record.data['idBuzon'];
             var idCab = record.data['idCabecera'];
             var mEst = record.data['marcoEstado'];
             var mMat = record.data['marcoMaterial'];
             var mNiv = record.data['marcoNivelado'];
             var media = record.data['media'];
             var prof = record.data['profundidad'];
             if (prof <= 0 || prof == null || prof.length == 0 || isNaN(prof)) {
                 alert('Ingrese un valor valido para Profundidad');
                 return false;
             }
             var sol = record.data['solado'];
             var tEst = record.data['tapaEstado'];
             var tMat = record.data['tapaMaterial'];
             var techo = record.data['techo'];
             var sella = record.data['sellado'];
             Ext.net.DirectMethods.ActualizaBuzon(buz, cuerpo, emboq, idBuz, idCab, mEst, mMat, mNiv, media, prof, sol, tEst, tMat, techo, sella);
         };
         
         var ModificarConexion = function () {
             var record = GridPanel3.getSelectionModel().getSelected();
             var pulg = record.data['pulgadas'];
             var dist = record.data['distancia'];
             var edist = record.data['TextField4'];
             if (dist <= 0 || dist == null || dist.length == 0 || edist <= 0 ) {
                 alert('Ingrese un valor valido para Distancia');
                 //    break;
                 return;
             }
             var izqDer = record.data['izqDer'];
             var tipoM = record.data['tipoMaterial'];
             //             if (tipoM == null || tipoM.length == 0) {
             //                 alert('Ingrese un valor valido para el Tipo de Material');
             //                 //record.getRowEditor().stopEditing();
             //                 return;
             //             }
             var idCab = record.data['IdCabecera'];
             var idCon = record.data['IdConexiones'];
             //record.getView().refresh();
             //alert(pulg+"-"+dist+"-"+izqDer+"-"+tipoM+"-"+idCab+"-"+idCon);
             Ext.net.DirectMethods.ActualizaConexion(pulg, dist, izqDer, tipoM, idCab, idCon);

         }

         var ModificaLimpieza = function () {
             var longi = Ext.get('longitud').dom.value;
             if (longi <= 0 || longi == null || longi.length == 0 || isNaN(longi)) {
                 alert('Ingrese un valor valido para Longitud');
                 return;
             }
             //alert(longi);
             var VolExt = Ext.get('VolExtraido').dom.value;
             if (VolExt <= 0 || VolExt == null || VolExt.length == 0 || isNaN(VolExt)) {
                 alert('Ingrese un valor valido para el Volumen');
                 return;
             }
             //             alert(VolExt);
             var Diam = Ext.get('Diametro').dom.value;
             if (Diam == null || Diam.length == 0) {
                 alert('Ingrese un valor para el Diámetro');
                 return;
             }
             //             alert(Diam);
             var FechaEj = Ext.get('dfFechaEj').dom.value;
             if (FechaEj == null || FechaEj.length == 0) {
                 alert('Ingrese un valor para la Fecha');
                 return;
             }
             //             alert(FechaEj);
             var hraI = Ext.get('horaI1').dom.value;
             if (hraI <= 0 || hraI >= 25 || isNaN(hraI)) {
                 alert('La HORA Ingresada en la Hora de Inicio no es correcta');
                 return;
             }
             var minI = Ext.get('minutoI1').dom.value;
             if (minI < 0 || minI > 59 || isNaN(minI)) {
                 alert('Los MINUTOS Ingresados en la Hora de Inicio no son correctos');
                 return;
             }
             var HIni = hraI + ":" + minI;
             //             alert(HIni);
             var horaF = Ext.get('horaF1').dom.value;
             if (horaF <= 0 || horaF >= 25 || isNaN(horaF)) {
                 alert('La HORA Ingresada en la Hora de Fin no es correcta');
                 return;
             }
             var minutoF1 = Ext.get('minutoF1').dom.value;
             if (minutoF1 < 0 || minutoF1 > 59 || isNaN(minutoF1)) {
                 alert('Los MINUTOS Ingresados en la Hora de Fin no son correctos');
                 return;
             }
             var HFin = horaF + ":" + minutoF1;
             //             alert(HFin);
             var Cuad = Ext.getCmp('cbCuadrilla').getValue();
             if (Cuad <= 0 || Cuad == null || Cuad.length == 0) {
                 alert('Seleccione una Cuadrilla');
                 return;
             }
             //             alert(Cuad);
             var MatTubo = Ext.get('cbMatTubo').dom.value;
             if (MatTubo == "Seleccione..." || MatTubo.length == 0) {
                 alert('Seleccione un Material');
                 return;
             }
             //             alert(MatTubo);
             var Tirante = Ext.get('Tirante').dom.value;
             if (Tirante <= 0 || Tirante == null || Tirante.length == 0 || isNaN(Tirante)) {
                 alert('Ingrese un valor valido para Tirante');
                 return;
             }
             //             alert(Tirante);
             var arena = Ext.getCmp('ckArena').getValue();
             //             alert(arena);
             var piedra = Ext.getCmp('ckPiedra').getValue();
             //             alert(piedra);
             var cascajo = Ext.getCmp('ckCascajos').getValue();
             //             alert(cascajo);
             var otros = Ext.getCmp('ckOtros').getValue();
             //             alert(otros);
             var otrosDesc = Ext.get('txtotros').getValue();
             if (otros == true && (otrosDesc == null || otrosDesc.length == 0)) {
                 alert('Debe Ingresar una Descripción de Otros');
                 return;
             }
             //             alert(otrosDesc);
             //alert(Cuad+""+arena+"" + piedra + ""+cascajo+"" + otros+"" + otrosDesc);
             Ext.net.DirectMethods.ActualizaLimpieza(longi, VolExt, Diam, FechaEj, HIni, HFin, Cuad, MatTubo, Tirante, arena, piedra, cascajo, otros, otrosDesc);
         }

         var ModificarDeficiencia = function () {
             var record = GridPanel4.getSelectionModel().getSelected();
             var cod = record.data['codigo'];
             var dist = record.data['distancia'];
             var puntual = record.data['puntual'];
             var extendida = record.data['extendida'];
             var idCab = record.data['IdCabecera'];
             var idDef = record.data['IdDeficiencias'];
             //alert(pulg+"-"+dist+"-"+izqDer+"-"+tipoM+"-"+idCab+"-"+idCon);
             Ext.net.DirectMethods.ActualizaDeficiencias(cod, dist, puntual, extendida, idCab, idDef);
         }

         var ModificaInspeccion = function () {
             var estado = Ext.get('cbEstado').dom.value;
             var Cuad = Ext.getCmp('cbCuadrillaInsp').getValue();
//             if (Cuad <= 0 || Cuad == null || Cuad.length == 0) {
//                 alert('Seleccione una Cuadrilla');
//                 return;
//             }
             var hraI = Ext.get('hi1').dom.value;

             if ( hraI >= 25 || isNaN(hraI)) {
                 alert('La HORA Ingresada en la Hora de Inicio no es correcta');
                 return;
             }
             var minI = Ext.get('mi1').dom.value;
             if ( minI > 59 || isNaN(minI)) {
                 alert('Los MINUTOS Ingresados en la Hora de Inicio no son correctos');
                 return;
             }
             var TIni = hraI + ":" + minI;
             //alert(TIni);
             var horaF = Ext.get('hf1').dom.value;
             if ( horaF >= 25 || isNaN(horaF)) {
                 alert('La HORA Ingresada en la Hora de Fin no es correcta');
                 return;
             }
             var minutoF = Ext.get('mf1').dom.value;
             if ( minutoF > 59 || isNaN(minutoF)) {
                 alert('Los MINUTOS Ingresados en la Hora de Fin no son correctos');
                 return;
             }
             var TFin = horaF + ":" + minutoF;
             //alert(TFin);
             var Fecha = Ext.get('dfFecha').dom.value;
             //alert(Cuad+""+arena+"" + piedra + ""+cascajo+"" + otros+"" + otrosDesc);
             Ext.net.DirectMethods.ActualizaInspeccion(estado, Cuad, TIni, TFin, Fecha);

         }
         
    </script>
    
    <ext:XScript ID="XScript1" runat="server">
        <script type="text/javascript">
            var addEmployee = function () {
                var grid = #{GridPanel3};
                grid.getRowEditor().stopEditing();
                
                grid.insertRecord(0, {
                    pulgadas   : "6",
                    distancia  : "1",
                    derIzq  : "D",
                    tipoMat : "",
                });
                
                grid.getView().refresh();
                grid.getSelectionModel().selectRow(0);
                grid.getRowEditor().startEditing(0);
               
               var record = GridPanel3.getSelectionModel().getSelected();
               var pulg = record.data['pulgadas'];
               var distancia = record.data['distancia'];
               var izqDer = record.data['izqDer'];
               var tipoM = record.data['tipoMaterial'];
               //alert(record.data['IdCabecera']);
               Ext.net.DirectMethods.RegistraConexion(pulg,distancia,izqDer,tipoM);
                
            }
            
            var removeEmployee = function () {
                var grid = #{GridPanel3};
                grid.getRowEditor().stopEditing();
                
                var record = GridPanel3.getSelectionModel().getSelected();
                var idCon = record.data['IdConexiones'];
                //alert(idCon);
                Ext.net.DirectMethods.EliminarConexion(idCon);

                var s = grid.getSelectionModel().getSelections();
                
                for (var i = 0, r; r = s[i]; i++) {
                    #{Store1}.remove(r);
                }
            }

            var addDeficiencias = function () {
                var grid1 = #{GridPanel4};
                grid1.getRowEditor().stopEditing();
                
                grid1.insertRecord(0, {
                    codigo   : 0,
                    distancia  : 0,
                    puntual  :true,
                    extendida : 0,
                });
                
                grid1.getView().refresh();
                grid1.getSelectionModel().selectRow(0);
                grid1.getRowEditor().startEditing(0);
                 
              var record = GridPanel4.getSelectionModel().getSelected();
              var cod = record.data['codigo'];
              var dist = record.data['distancia'];
              var puntual = record.data['puntual'];
              var extendida = record.data['extendida'];
//               //alert(pulg + distancia + izqDer + tipoM);
              Ext.net.DirectMethods.RegistraDeficiencia(cod,dist,puntual,extendida);
                
            }
            
            var removeDeficiencias = function () {
                var grid = #{GridPanel4};
                grid.getRowEditor().stopEditing();
                
                var record = GridPanel4.getSelectionModel().getSelected();
                var idDef = record.data['IdDeficiencias'];
                //alert(idDef);
                Ext.net.DirectMethods.EliminarDeficiencia(idDef);

                var s = grid.getSelectionModel().getSelections();
                
                for (var i = 0, r; r = s[i]; i++) {
                    #{Store1}.remove(r);
                }
            }
        </script>
    </ext:XScript>

    <%--   Fin D--%>
    <%-- Actividad A--%>
    <script type="text/javascript">
        var MuestraPanel = function () {

            var ub = ckUbica.getValue();
            if (ub == 1) {
                // alert(ub + "true");
                var div = document.getElementById('panUbica');
                div.style.display = 'block';
                Ext.getCmp('ckMyT').show();
                Ext.getCmp('ckLosa').show();
                Ext.getCmp('rbsi').show();
                Ext.getCmp('rbno').show();
            }
            else {
                // alert(ub + "false");
                Ext.getCmp('ckMyT').hide();
                Ext.getCmp('ckLosa').hide();
                Ext.getCmp('rbsi').hide();
                Ext.getCmp('rbno').hide();
                var div = document.getElementById('panUbica');
                div.style.display = 'none';
            }

        };

        var GuardarPurga = function () {
            var sector = Ext.get('Sector').dom.value;
            if (sector < 0  || sector.length==0 || (/,/.test(sector)) ) {
                alert('El valor ingresado en SECTOR  no es correcto');
                return;
            }
            var cloro = Ext.get('Cloro').dom.value;
            if (cloro < 0 || cloro.length == 0 || isNaN(cloro) || (/,/.test(cloro))) {
                alert('El valor ingresado en CLORO  no es correcto');
                return;
            }
            var tpurga = Ext.get('Tpurga').dom.value;
            if (tpurga < 0 || tpurga.length == 0 || isNaN(tpurga) || (/,/.test(tpurga))) {
                alert('El valor ingresado en CLORO  no es correcto');
                return;
            }
            var presion = Ext.get('Presion').dom.value;
            if (presion < 0 || presion.length == 0 || isNaN(presion) || (/,/.test(presion))) {
                alert('El valor ingresado en Presion no es correcto');
                return;
            }
            var caractAgua = Ext.get('cbCaractAgua').dom.value;
            if (caractAgua == "Seleccione..." || caractAgua.length == 0) {
                 alert('Seleccione una Caracteristica del Agua');
                 return;
             }
            var OpInop = Ext.get('Countries').dom.value;
            if (OpInop == "Seleccione..." || OpInop.length == 0) {
                alert('Seleccione Grifo contra Incendio: Operativo - Inoperativo');
                return;
            }
            var nroBoca = Ext.get('nroBocas').dom.value;
            if (nroBoca < 0 || nroBoca.length == 0 || (/,/.test(nroBoca))) {
                alert('El valor ingresado en Nro Bocas  no es correcto');
                return;
            }
            var detOpInop = Ext.get('Cities').dom.value;
            if (detOpInop == "Cargando..." || detOpInop.length == 0) {
                alert('Seleccione tipo de Grifo');
                return;
            }
            var nroTapa = Ext.get('nroTapas').dom.value;
            if (nroTapa < 0 || nroTapa.length == 0 || (/,/.test(nroTapa))) {
                alert('El valor ingresado en Nro Tapas  no es correcto');
                return;
            }
            var marca = Ext.get('marca').dom.value;
            if (marca.length == 0) {
                alert('El valor ingresado en MARCA no es correcto');
                return;
            }
            var cgi = Ext.get('cbCGI').dom.value;
            if (cgi == "Seleccione..." || cgi.length == 0) {
                alert('Seleccione CGI');
                return;
            }
            var ubica = ckUbica.getValue();
            var myt = ckMyT.getValue();
            var losa = ckLosa.getValue();
            var mantsi = rbsi.getValue();
            var mantno = rbno.getValue();
            var ANF = Ext.get('ANF').dom.value;
            if (ANF.length == 0 || ANF < 0 || isNaN(ANF) || (/,/.test(ANF))) {
                alert('El valor ingresado en ANF no es correcto');
                return;
            }
            var obs = Ext.get('taObs').dom.value;
            if (obs.length == 0) {
                alert('El valor ingresado en Obseración no es correcto');
                return;
            }
            var colorAgua = Ext.get('cbColorAgua').dom.value;
            if (colorAgua == "Seleccione..." || colorAgua.length == 0) {
                alert('Seleccione Color de Agua');
                return;
            }
            var descarga = Ext.get('cbDescarga').dom.value;
            if (descarga == "Seleccione..." || descarga.length == 0) {
                alert('Seleccione Descarga En');
                return;
            }
            var distancia = Ext.get('Distancia').dom.value;
            if (distancia.length == 0 || distancia == 0 || distancia < 0 || isNaN(distancia) || (/,/.test(distancia))) {
                alert('El valor ingresado en Distancia no es correcto');
                return;
            }
           // alert( ubica + 'g' + myt + 'g' + losa + 'g' + mantsi + 'g' + mantno + 'g' );
            Ext.net.DirectMethods.ActualizaPurga(sector, cloro, tpurga, presion, caractAgua, OpInop, nroBoca, detOpInop, nroTapa, marca,
             cgi, ubica, myt, losa, mantsi, mantno, ANF, obs, colorAgua, descarga, distancia);
        }
        var CancelarPurga = function () {
        }
    </script>
    <%-- Fin A--%>
    <%-- Actividad B--%>
    <script runat="server">
        protected void CitiesRefresh(object sender, StoreRefreshDataEventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(HttpContext.Current.Server.MapPath("Cities.xml"));
            List<object> data = new List<object>();

            foreach (XmlNode cityNode in xmlDoc.SelectNodes(string.Concat("countries/country[@code='", this.Countries.SelectedItem.Value, "']/city")))
            {
                string id = cityNode.SelectSingleNode("id").InnerText;
                string name = cityNode.SelectSingleNode("name").InnerText;
                data.Add(new { Id = id, Name = name });
            }
            this.CitiesStore.DataSource = data;

            this.CitiesStore.DataBind();
        }
    </script>
     <script type="text/javascript">
         var GuardarCaracteristicas = function () {
             var Valvueltas = Ext.get('Nvueltas').dom.value;
             if (Valvueltas < 0 || Valvueltas.length == 0 || isNaN(Valvueltas) || (/,/.test(Valvueltas))) {
                 alert('El valor ingresado en Nro. de Vueltas  no es correcto');
                 return;
             }

             var ValIzq = rbIzq.getValue();
             var ValDer = rbDer.getValue();

             var ValNivApert = Ext.get('NivApert').dom.value;
             if (ValNivApert < 0 || ValNivApert.length == 0 || isNaN(ValNivApert) || (/,/.test(ValNivApert))) {
                 alert('El valor ingresado en Nivel de Apertura no es correcto');
                 return;
             }

             var ValEstado = Ext.get('cbEstValvul').dom.value;
             if (ValEstado == "Seleccione..." || ValEstado.length == 0) {
                 alert('Seleccione el Estado de la Válvula');
                 return;
             }
             var ValMarca = Ext.get('marcaCar').dom.value;
             if (ValMarca.length == 0  ) {
             alert('El valor ingresado en Marca no es correcto');
             return;
             }
             var GrifDiametro = Ext.get('cbDiametro').dom.value;
             if (GrifDiametro == "Seleccione..." || GrifDiametro.length == 0) {
             alert('Seleccione una Caracteristica del Agua');
             return;
             }
             var GrifoBocas = Ext.get('txtBocas').dom.value;
             if (GrifoBocas < 0 || GrifoBocas.length == 0 || isNaN(GrifoBocas) || (/,/.test(GrifoBocas))) {
                 alert('El valor ingresado en Nro. de Bocas no es correcto');
                 return;
             }

             var GrifMarca = Ext.get('txtMarca').dom.value;
             if (GrifMarca.length == 0) {
             alert('El valor ingresado en Marca no es correcto');
             return;
             }
             var GrifVueltas = Ext.get('txtVueltas').dom.value;
             if (GrifVueltas < 0 || GrifVueltas.length == 0 || isNaN(GrifVueltas) || (/,/.test(GrifVueltas))) {
                 alert('El valor ingresado en Nro de Vueltas no es correcto');
                 return;
             }
             var GrifSec = Ext.get('txtSec').dom.value;
             if (GrifSec < 0 || GrifSec.length == 0 || isNaN(GrifSec) || (/,/.test(GrifSec))) {
             alert('El valor ingresado en Sector no es correcto');
             return;
             }
             var GrifVueltAb = Ext.get('txtVueltasAb').dom.value;
             if (GrifVueltAb < 0 || GrifVueltAb.length == 0 || isNaN(GrifVueltAb) || (/,/.test(GrifVueltAb))) {
             alert('El valor ingresado en Nro Vueltas Abiertas no es correcto');
             return;
             }
             var Op = rbOp.getValue();
             var Inop = rbInop.getValue();

             var TapBoc = Ext.get('txtNroTapBoc').dom.value;
             if (TapBoc < 0 || TapBoc.length == 0 || isNaN(TapBoc) || (/,/.test(TapBoc))) {
             alert('El valor ingresao en Nro Tapa Boca masa no es correcto');
             return;
             }

             var seco = rbseco.getValue();
             var hum = rbHum.getValue();


             var ubica = Ext.get('cbOtrUbica').dom.value;
             if (ubica == "Seleccione..." || ubica.length == 0) {
             alert('Seleccione Ubicacion');
             return;
             }
             var ubicaVal = Ext.get('cbOtrUbicaVal').dom.value;


             // alert( ubica + 'g' + myt + 'g' + losa + 'g' + mantsi + 'g' + mantno + 'g' );
             Ext.net.DirectMethods.ActualizaCaracteristicas(Valvueltas, ValIzq, ValDer, ValNivApert,
             ValEstado, ValMarca, GrifDiametro, GrifoBocas, GrifMarca, GrifVueltas, GrifSec, GrifVueltAb, Op, Inop, TapBoc, seco, hum, ubica, ubicaVal);
         }
    </script>
    <%-- Fin B--%>
    <%-- OTROS !!!!--%>
    <script type="text/jscript">
        var GuardarACtD1 = function () {
            var AltSolBuzon = Ext.get('txtAltSolBuzon').dom.value;
            if (isNaN(AltSolBuzon)) {
                alert('Ingrese un valor valido para Altura de Sólidos en Buzón');
                return;
            }
            var PulgIntBuzon = Ext.get('PulgIntBuzon').dom.value;
            if (isNaN(PulgIntBuzon)) {
                alert('Ingrese un valor valido para Pulgadas Interno de Buzón');
                return;
            }
            var VolExtSolido = Ext.get('txtVolExtSolido').dom.value;
            if (isNaN(VolExtSolido)) {
                alert('Ingrese un valor valido para Volúmen Extraído Sólidos');
                return;
            }
            var TirHidFlujo = Ext.get('txtTirHidFlujo').dom.value;
            if (isNaN(TirHidFlujo)) {
                alert('Ingrese un valor valido para Tirante Hidráulico Flujo');
                return;
            }
            var DiamColector = Ext.get('txtDiamColector').dom.value;
            if (DiamColector < 0) {
                alert('Ingrese un Valor Válido para Diámetro Colector');
                return;
            }
            var AltAguaRet = Ext.get('txtAltAguaRet').dom.value;
            if (isNaN(AltAguaRet)) {
                alert('Ingrese un valor valido para Altura de Agua Retenida');
                return;
            }
            var AltTotBuzon = Ext.get('txtAltTotBuzon').dom.value;
            if (isNaN(AltTotBuzon)) {
                alert('Ingrese un valor valido para Altura total Buzón');
                return;
            }
            var OtrosD1 = Ext.get('taOtrosD1').dom.value;
            //alert(OtrosD1);
            var rbDesmsi = RbDesmontSi.getValue();
            //alert(rbDesmsi);
            var rbAgsi = RbAguaSi.getValue();
            Ext.net.DirectMethods.ActualizaDUno(AltSolBuzon, PulgIntBuzon, VolExtSolido, TirHidFlujo,
            DiamColector, AltAguaRet, AltTotBuzon, OtrosD1, rbDesmsi, rbAgsi);
        }
    </script>
    <script type="text/jscript">
        var GuardarDVD = function () {
            var DVD = Ext.get('txtDVD').dom.value;
            if (isNaN(DVD)) {
                alert('Ingrese un valor valido para Altura de Sólidos en Buzón');
                return;
            }
            Ext.net.DirectMethods.ActualizaDVD(DVD);
        }
    </script>
 <%--   Fin--%>
</head>
<body style="background-color:#D0DEF0;">
    <form id="form1" runat="server">
	<ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />
	<ext:ResourceManager ID="ResourceManager1" runat="server"/>
		<ext:Toolbar runat="server" ID="barra">
			<Items>
				<ext:ButtonGroup ID="ButtonGroup1" runat="server" Title="ACCIONES">
					<Items>
						<ext:Button ID="btnPNuevo" 
                            runat="server" 
                            Text="Nuevo" 
                            IconCls="nuevo" 
                            Scale="Large" 
                            IconAlign="Top"
							ToolTip="Nuevo"
							ToolTipType="Qtip">
                                <DirectEvents>
									<Click OnEvent="btnPNuevo_Click"></Click>
								</DirectEvents>
                            </ext:Button>
							<ext:Button ID="btnPBuscar" 
                            runat="server" 
                            Text="Buscar" 
                            IconCls="buscar" 
                            Scale="Large" 
                            IconAlign="Top" 
							ToolTip="Buscar"
							ToolTipType="Qtip">
								<DirectEvents>
									<Click OnEvent="btnPBuscar_Click"></Click>
								</DirectEvents>
							</ext:Button>
						 <ext:Button ID="btnPGuardar" 
                            runat="server" 
                            Text="Guardar" 
                            IconCls="guardar" 
                            Scale="Large" 
                            IconAlign="Top"
							ToolTip="Guardar"
							ToolTipType="Qtip">
								<DirectEvents>
									<Click OnEvent="btnPGuardar_Click" Timeout="36000" ></Click>
								</DirectEvents>
							</ext:Button>
						 <ext:Button ID="btnPCancelar" 
                            runat="server" 
                            Text="Cancelar" 
                            IconCls="cancelar" 
                            Scale="Large" 
                            IconAlign="Top" 
							ToolTip="Cancelar"
							ToolTipType="Qtip">
							<DirectEvents>
								<Click OnEvent="btnPCancelar_Click" >
									<EventMask ShowMask="true" />
								</Click>
							</DirectEvents>
						</ext:Button>
						
					</Items>
				</ext:ButtonGroup>
				<ext:ButtonGroup ID="ButtonGroup2" runat="server" Title="AGREGAR">
					<Items>
						 <ext:Button ID="btnPSubAct" 
                            runat="server" 
                            Text="Sub-Actividad" 
                            IconCls="subactividad" 
                            Scale="Large" 
                            IconAlign="Top">
								<DirectEvents>
									<Click OnEvent="AgregarSubActividad"></Click>
								</DirectEvents>
							</ext:Button>
						 <ext:Button ID="btnPMaterial" 
                            runat="server" 
                            Text="Materiales" 
                            IconCls="materiales" 
                            Scale="Large" 
                            IconAlign="Top">
                                <Listeners>
                                    <Click Fn="AgregaMaterial" />
                                </Listeners>
							</ext:Button>
						<ext:Button ID="btnPTC" 
                            runat="server" 
                            Text="Trabajo Complementario" 
                            IconCls="trabajocomplementario" 
                            Scale="Large" 
                            IconAlign="Top">
								<DirectEvents>
									<Click OnEvent="AgregarTC"></Click>
								</DirectEvents>
							</ext:Button>
					</Items>
				</ext:ButtonGroup>
				<ext:ButtonGroup ID="ButtonGroup3" runat="server" Title="EMISIÓN">
					<Items>
						 <ext:Button ID="btnPImprimir" 
                            runat="server" 
                            Text="Imprimir" 
                            IconCls="imprimir" 
                            Scale="Large" 
                            IconAlign="Top" />
					</Items>
				</ext:ButtonGroup>
			</Items>
		</ext:Toolbar>
        <ext:Hidden ID="hdnTipoAccion" runat="server">
        </ext:Hidden>
		<ext:Panel ID="Panel1" runat="server" Title="1. Datos Orden Trabajo" Frame="true" Padding="2" >
			<Content>
				<table cellpadding="3" cellspacing="3" border="0">
					<tr>
						<td style="width:55px;">Local</td>
						<td style="padding-left:5px;">
							<ext:ComboBox ID="ddlObra" runat="server" DisplayField="DescripcionCorta" ValueField="IdObra" EmptyText="[Seleccione Obra]" Width="200px">
								<Store>
									<ext:Store ID="StoreObra" runat="server">
										<Reader>
											<ext:JsonReader IDProperty="IdObra">
												<Fields>
													<ext:RecordField Name="IdObra" />
													<ext:RecordField Name="DescripcionCorta" />
												</Fields>
											</ext:JsonReader>
										</Reader> 
									</ext:Store>
								</Store>
								 <DirectEvents>
                                    <Select OnEvent="CuadrillasPorObra"></Select>
                                </DirectEvents>
							</ext:ComboBox>
						</td>
						<td style="padding-left:5px;width:70px;color:Red;font-weight:bold; font-size:10px;">N° Parte Trabajo</td>
						<td style="padding-left:5px;">
							<ext:Hidden ID="hdnIdCabecera" runat="server"></ext:Hidden>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td><ext:TextField ID="txtPSGIO" runat="server" Width="70px" StyleSpec="font-weight:bold; font-size:13px;border:1px solid red;"></ext:TextField></td>
                                    <td style="padding-left:5px;">
                                        <ext:ImageButton ID="imgBuscarSGIO" runat="server" ImageUrl="../../../../../Libreria/Imagenes/search2.png">
                                            <DirectEvents>
                                                <Click OnEvent="BuscarPorSGIO" Timeout="1200000">
										            <EventMask ShowMask="true" Msg="Cargando Datos" />
                                                 </Click>
								            </DirectEvents>
                                            
                                        </ext:ImageButton>
                                    </td>
                                </tr>
                            </table>
						</td>
                        <td style="padding-left:15px; "></td>
						<td style="padding-left:5px;">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td><ext:TextField ID="txtPCorrelativo" runat="server" Width="70px" Visible=false></ext:TextField></td>
                                    <td style="padding-left:5px;">
                                        <ext:ImageButton  ID="ImageButton1" runat="server" ImageUrl="../../../../../Libreria/Imagenes/search2.png" Visible=false>
                                            <DirectEvents>
                                                <Click OnEvent="BuscarPorCorrelativo" Timeout="1200000"> 
                                                 <EventMask ShowMask="true" Msg="Cargando Datos" />
                                                 </Click>
                                            </DirectEvents>
                                        </ext:ImageButton>
                                    </td>
                                </tr>
                            </table>
						</td>
						<td style="padding-left:15px;width:55px;"></td>
						<td style="padding-left:5px;">
							<ext:TextField ID="txtPNIS" runat="server" Width="70px" Visible=false></ext:TextField>
						</td>
						<td style="padding-left:15px;width:55px;color:Red;font-weight:bold; font-size:10px;">Nro. Orden Trabajo</td>
						<td style="padding-left:5px;">
                        <table cellpadding="0" cellspacing="0">
                        <tr>
							<td> <ext:TextField ID="txtPOrden" runat="server" Width="75px" StyleSpec="font-weight:bold; font-size:13px;border:1px solid red;" ></ext:TextField></td>
                            <td style="padding-left:5px;">
                                 <ext:ImageButton ID="ImageButton2" runat="server" ImageUrl="../../../../../Libreria/Imagenes/search2.png">
                                      <DirectEvents>
                                           <Click OnEvent="BuscarPorNROOT" Timeout="1200000">
                                            <EventMask ShowMask="true" Msg="Cargando Datos" />
                                                 </Click>
                                       </DirectEvents>
                                  </ext:ImageButton>
                            </td>
                            </tr>
                            </table>
                            </td>
							<ext:DateField ID="txtPFecOrden" runat="server" Hidden="true"></ext:DateField>
					</tr>
					<tr>
						<td>Distrito</td>
						<td style="padding-left:5px;">
							<ext:ComboBox ID="ddlDistrito" runat="server" DisplayField="Distrito" ValueField="IdDistrito" Width="200px">
								<Store>
									<ext:Store ID="StoreDistrito" runat="server">
										<Reader>
											<ext:JsonReader IDProperty="IdDistrito">
												<Fields>
													<ext:RecordField Name="IdDistrito" />
													<ext:RecordField Name="Distrito" />
												</Fields>
											</ext:JsonReader>
										</Reader>
									</ext:Store>
								</Store>
							</ext:ComboBox>
						</td>
						
                        <%--<td style="padding-left:5px;">Contacto Cliente</td>
						<td colspan="3" style="padding-left:5px;">
							<ext:TextField ID="txtPUrbanizacion" runat="server" Width="265" />
						</td>--%>
						<td style="padding-left:15px;">Dirección</td>
						<td colspan="4" style="padding-left:5px;">
							<ext:TextField ID="txtPDireccion" runat="server" Width="320" />
						</td>
					</tr>
                    
                    <tr>
                   
                   <td style="padding-left:15px;">Cliente</td>
						<td colspan="4" style="padding-left:5px;">
							<ext:TextField ID="txtPCliente" runat="server" Width="320" />
						</td>

                        <td style="color:Red;padding-left:5px;font-weight:bold; font-size:10px;">V°B° del usuario final en el Cliente</td>
						<td colspan="3" style="padding-left:5px;">
							<ext:TextField ID="txtPUrbanizacion" runat="server" Width="300" StyleSpec="font-weight:bold; font-size:13px;border:1px solid red;"/>
						</td>

                    </tr>
					
                    <tr>
						<td>Actividad</td>
						<td colspan="5" style="padding-left:5px;">
							<ext:ComboBox ID="ddlPActividad" runat="server" DisplayField="Descripcion1" ValueField="IdActividad" EmptyText="[Seleccione Actividad]" Width="550px"
									ItemSelector="div.list-item">
									<Store>
										<ext:Store ID="StoreNActividad" runat="server">
											<Reader>
												<ext:JsonReader IDProperty="IdActividad">
													<Fields>
														<ext:RecordField Name="IdActividad" />
														<ext:RecordField Name="CodMap" />
														<ext:RecordField Name="Descripcion1" />
														<ext:RecordField Name="Descripcion2" />
													</Fields> 
												</ext:JsonReader>
											</Reader>
										</ext:Store>
									</Store>
									<Template ID="Template2" runat="server">
										<Html>
											<tpl for=".">
												<div class="list-item">
													<b>{Descripcion1}</b> - {Descripcion2}
												</div>
											</tpl>
										</Html>
									</Template>
								</ext:ComboBox>
						</td>
                        <td style="padding-left:15px;">Estado</td>
						<td style="padding-left:5px;">
							<ext:ComboBox ID="ddlPEstado" runat="server" DisplayField="DescripcionEstado" ValueField="IdEstadoOT" Width="110px">
								<Store>
									<ext:Store ID="StoreEstado" runat="server">
										<Reader>
											<ext:JsonReader IDProperty="IdEstadoOT">
												<Fields>
													<ext:RecordField Name="IdEstadoOT" />
													<ext:RecordField Name="DescripcionEstado" />
												</Fields>
											</ext:JsonReader>
										</Reader>
									</ext:Store>
								</Store>
							</ext:ComboBox>
						</td>
                        <td style="padding-left:15px;">Estado Planificado</td>
						<td style="padding-left:5px;">
							<ext:ComboBox ID="ddlPEstadoRO" runat="server" DisplayField="DescripcionEstado" ValueField="IdEstadoOT" Width="110px" Disabled="true">
								<Store>
									<ext:Store ID="StoreEstadoRO" runat="server">
										<Reader>
											<ext:JsonReader IDProperty="IdEstadoOT">
												<Fields>
													<ext:RecordField Name="IdEstadoOT" />
													<ext:RecordField Name="DescripcionEstado" />
												</Fields>
											</ext:JsonReader>
										</Reader>
									</ext:Store>
								</Store>
							</ext:ComboBox>
						</td>
						<%--<td style="padding-left:15px;">Fec. Prog.</td>
						<td style="padding-left:5px;">--%>
							<ext:DateField ID="txtPFecProg" runat="server" Hidden="true"></ext:DateField>
						<%--</td>--%>
					</tr>
					<tr>
						<td>Fec. Inicio</td>
						<td style="padding-left:5px;">
							<table cellpadding="0" cellspacing="0">
								<tr>
									<td>
										<ext:DateField ID="txtPFecIni" runat="server"></ext:DateField>
									</td>
									<td>
										<ext:TextField ID="txtPHorIni" runat="server" Width="80px">
										</ext:TextField>
										<%--<asp:TextBox ID="txtPHorIni" runat="server" CssClass="x-form-text x-form-field" Width="80px" Height="18px"></asp:TextBox>
										<ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtPHorIni" MaskType="Time" AcceptAMPM="true" Mask="99:99">
										</ajaxToolkit:MaskedEditExtender>--%>
									</td>
								</tr>
							</table>
						</td>
						<td style="padding-left:5px;">Fec. Término</td>
						<td colspan="3" style="padding-left:5px;">
							<table cellpadding="0" cellspacing="0">
								<tr>
									<td>
										<ext:DateField ID="txtPFecFin" runat="server"></ext:DateField>
									</td>
									<td>
										<ext:TextField ID="txtPHorFin" runat="server" Width="80px">
										</ext:TextField>
										<%--<asp:TextBox ID="txtPHorFin" runat="server" CssClass="x-form-text x-form-field" Width="80px" Height="18px"></asp:TextBox>
										<ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtPHorFin" MaskType="Time" AcceptAMPM="true" Mask="99:99">
										</ajaxToolkit:MaskedEditExtender>--%>
									</td>
								</tr>
							</table>
						</td>
						
                        <td style="padding-left:15px;">Asignado</td>
						<td style="padding-left:5px;" colspan="3">
                            <ext:ComboBox ID="ddlPCuadrilla" runat="server" DisplayField="Descripcion" ValueField="IdCuadrilla" Width="300px" ItemSelector="div.list-item"
                            Editable="true" 
							TypeAhead="true" 
							Mode="Local" 
							ForceSelection="true" 
							TriggerAction="All" 
                            >
								<Store>
									<ext:Store ID="StoreCuadrilla" runat="server">
										<Reader>
											<ext:JsonReader IDProperty="IdCuadrilla">
												<Fields>
													<ext:RecordField Name="IdCuadrilla" />
													<ext:RecordField Name="Descripcion" />
													<ext:RecordField Name="DetalleZona" />
													<ext:RecordField Name="NombresApellidos" />
												</Fields>
											</ext:JsonReader>
										</Reader>
									</ext:Store>
								</Store>
								<Template ID="Template1" runat="server">
									<Html>
										<tpl for=".">
											<div class="list-item">
												<b>{Descripcion}</b><br />{NombresApellidos}<br />{DetalleZona}
											</div>
										</tpl>
									</Html>
								</Template>
							</ext:ComboBox>
						</td>
                        
						
					</tr>
					<tr>
						<td>Cargo N°</td>
                        <td style="padding-left:5px;">
							<ext:TextField ID="txtPNroCargo" runat="server" Width="180" ReadOnly="true" />
						</td>
						<td style="padding-left:5px;">Hrs Trab.</td>
						<td style="padding-left:5px;">
							<ext:TextField ID="txtHorTrab" runat="server" Width="50" />
						</td>
						<td style="padding-left:15px;">Nro. Trab.</td>
						<td style="padding-left:5px;">
							<ext:TextField ID="txtNroTrab" runat="server" Width="50" />
						</td>
                        <td style="padding-left:15px;"></td>
						<td style="padding-left:5px;">
							<ext:TextField ID="TextTotalOT" runat="server" Width="100" ReadOnly="true" Visible=false />
						</td>
                        <td style="padding-left:15px;"></td>
						<td style="padding-left:5px;">
							<ext:TextField ID="TextTotalSGIO" runat="server" Width="100" ReadOnly="true" Visible=false />
						</td>
					</tr>
				</table>
			</Content>
		</ext:Panel>
         <ext:TabPanel ID="TabPanel1" runat="server" Frame="true">
            <Items>
		<ext:Panel ID="Panel2" runat="server" AutoHeight="true" Title="2. Detalle Orden Trabajo" Frame="true">
			<Content>
            <table>
            <tr>
            <td style="vertical-align:top;">
				<ext:GridPanel 
				ID="GridPanel1" 
				runat="server" 
                width="850"
                Height="250px"
				>
				<Store>
					<ext:Store ID="StoreEjecucionOT" runat="server" GroupField="IdTipo">
						<Reader>
							<ext:JsonReader IDProperty="Item">
								<Fields>
									<ext:RecordField Name="Item" /> 
									<ext:RecordField Name="IdTipo" /> 
									<ext:RecordField Name="Tipo" /> 
									<ext:RecordField Name="ID" />
									<ext:RecordField Name="Descripcion" />

                                    <ext:RecordField Name="Observacion" />

									<ext:RecordField Name="Unidad" />
									<ext:RecordField Name="Cantidad" />
									<ext:RecordField Name="Precio" />
									<ext:RecordField Name="SubTotal" />
									<ext:RecordField Name="SGIO" />
								</Fields>
							</ext:JsonReader>
						</Reader>
					</ext:Store>
				</Store>
				<ColumnModel ID="ColumnModel1" runat="server">
					<Columns>
						<ext:CommandColumn Width="60px" ButtonAlign="Center">
							<Commands>
								<ext:GridCommand Icon="Cross" CommandName="Eliminar">
									<ToolTip Text="Eliminar" />
								</ext:GridCommand>
								<ext:CommandSeparator />
								<ext:GridCommand Icon="NoteEdit" CommandName="Editar">
									<ToolTip Text="Editar" />
								</ext:GridCommand>
							</Commands>
							<PrepareToolbar Fn="prepareToolbar" />
						</ext:CommandColumn>
						<ext:Column ColumnID="Item" Header="Item" DataIndex="Item" Width="40px" />
						<ext:Column ColumnID="IdTipo" Header="IdTipo" DataIndex="IdTipo" />
						<ext:Column ColumnID="Tipo" Header="Tipo" DataIndex="Tipo" Width="150" Hidden="true" />
						<ext:Column ColumnID="Codigo" Header="Código" DataIndex="Codigo" Width="60px" />
						<ext:Column ColumnID="Descripcion" Header="Descripción" DataIndex="Descripcion" Width="350px"/>
                        <ext:Column ColumnID="Observacion" Header="Observacion" DataIndex="Observacion" Width="350px"/>
						<ext:Column ColumnID="Unidad" Header="Unidad" DataIndex="Unidad" Width="60px" />
						<ext:Column ColumnID="Cantidad" Header="Cantidad Horas" DataIndex="Cantidad" Width="80px"/>
						<ext:Column ColumnID="Precio" Header="Precio" DataIndex="Precio" Width="80px" />
						<ext:Column ColumnID="SubTotal" Header="SubTotal" DataIndex="SubTotal" Width="80px" />
						<ext:Column ColumnID="SGIO" Header="SGIO" DataIndex="SGIO" Hidden="true" />
					</Columns>
				</ColumnModel>
				<LoadMask ShowMask="true"/>
				<SaveMask ShowMask="true" />
				<Listeners>
					<Command Handler="ManejoConsumo(command, record.data.IdTipo,record.data.ID,record.data.Unidad);" />
				</Listeners>
				<View>
					<ext:GroupingView  
						ID="GroupingView1"
						HideGroupedColumn="true"
						runat="server" 
						ForceFit="false"
						StartCollapsed="false"
						EnableRowBody="true"
						GroupTextTpl="{[values.rs[0].data.Tipo]}"
						>
						<Listeners>
							<Refresh Fn="setGroupStyle" />
						</Listeners>
					</ext:GroupingView>
				</View>
			</ext:GridPanel>
            </td>
            <td style="padding-left:15px;">
                <table border="0">
                    <tr>
                        <td>Cargo</td>
                        <td style="padding-left:5px;">
                            <ext:ComboBox ID="ddlCargo" runat="server" DisplayField="NombreCargo" ValueField="IdCargoEntrega" Width="150px"
                            Editable="true" 
							TypeAhead="true" 
							Mode="Local" 
							ForceSelection="true" 
							TriggerAction="All">
								<Store>
									<ext:Store ID="StoreCargo" runat="server">
										<Reader>
											<ext:JsonReader IDProperty="IdCargoEntrega">
												<Fields>
                                                    <ext:RecordField Name="IdCargoEntrega" /> 
													<ext:RecordField Name="NombreCargo" />
												</Fields>
											</ext:JsonReader>
										</Reader>
									</ext:Store>
								</Store>
                                <DirectEvents>
                                    <Select OnEvent="CargaCargosSGI"></Select>
                                </DirectEvents>
							</ext:ComboBox>
                        </td>
                        <td style="width:150px; padding-left:5px;">
                            <ext:Button ID="Button2" runat="server" Text="" Icon="Add">
                                <Listeners>
                                    <Click Handler="#{Window5}.show();" />
                                </Listeners>
                            </ext:Button>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="padding-top:5px;">
                            <ext:GridPanel 
				                ID="GridPanel2" 
				                runat="server" 
                                width="250"
                                Height="200px"
				                >
				                    <Store>
					                    <ext:Store ID="StoreCargoSGI" runat="server">
						                    <Reader>
							                    <ext:JsonReader IDProperty="Descripcion">
								                    <Fields>
									                    <ext:RecordField Name="Item" /> 
									                    <ext:RecordField Name="IdTipo" /> 
									                    <ext:RecordField Name="Tipo" /> 
									                    <ext:RecordField Name="ID" />
									                    <ext:RecordField Name="Descripcion" />
									                    <ext:RecordField Name="Unidad" />
									                    <ext:RecordField Name="Cantidad" />
									                    <ext:RecordField Name="Precio" />
									                    <ext:RecordField Name="SubTotal" />
									                    <ext:RecordField Name="SGIO" />
								                    </Fields>
							                    </ext:JsonReader>
						                    </Reader>
					                    </ext:Store>
				                    </Store>
				                    <ColumnModel ID="ColumnModel3" runat="server">
                                        
					                    <Columns>
                                            
                                            <ext:Column ColumnID="Tipo" Header="Fecha" DataIndex="Tipo" Width="120px" />
						                    <ext:Column ColumnID="Descripcion" Header="N° Parte Trabajo" DataIndex="Descripcion" Width="70px" />
                                            <ext:CommandColumn Width="30px" ButtonAlign="Center">
							                    <Commands>
								                    <ext:GridCommand Icon="Cross" CommandName="EliminarSGI">
									                    <ToolTip Text="Eliminar" />
								                    </ext:GridCommand>
							                    </Commands>
						                    </ext:CommandColumn>
					                    </Columns>
				                    </ColumnModel>
				                <LoadMask ShowMask="true"/>
				                <SaveMask ShowMask="true" />
                                <Listeners>
					                <Command Handler="EliminarSGICargo(command, record.data.Descripcion);" />
				                </Listeners>
			                </ext:GridPanel>
                        </td>
                    </tr>
                    <tr>
                        <td>Conteo:</td>
                        <td style="padding-left:5px;">
                            <b>
                            <ext:Label ID="lblConteoSGI" runat="server">
                            </ext:Label>
                            </b>
                        </td>
                    </tr>
                </table>
                
            </td>
            </tr>
            
            </table>
			</Content>
		</ext:Panel>
        <ext:Panel 
                        ID="Panel5"
                        runat="server" 
                        Title="3. Detalle Buzones" 
                        AutoHeight="true"
                        BodyPadding="6" Visible=false>
                            <Content>
                            
                             <ext:GridPanel 
                ID="GridPanel5" 
                runat="server" 
                Title="" 
                height="120px" >
                 <Store>
                <ext:Store ID="storeBuzonxSGI" runat="server" SerializationMode="Complex">
                <Reader>
                        <ext:JsonReader IDProperty="idBuzon">
                            <Fields>
                                <ext:RecordField Name="buzon" />
                                <ext:RecordField Name="cuerpo" Type="Boolean" />
                                <ext:RecordField Name="emboquillado" Type="Boolean" />
                                <ext:RecordField Name="idBuzon" />
                                <ext:RecordField Name="idCabecera" />
                                <ext:RecordField Name="marcoEstado" Type="Boolean" />
                                <ext:RecordField Name="marcoMaterial"  />
                                <ext:RecordField Name="marcoNivelado" Type="Boolean"/>
                                <ext:RecordField Name="media" Type="Boolean" />
                                <ext:RecordField Name="profundidad" Type="Float" />
                                <ext:RecordField Name="sellado" Type="Boolean"/>
                                <ext:RecordField Name="solado" Type="Boolean" />
                                <ext:RecordField Name="tapaEstado" Type="string"/>
                                <ext:RecordField Name="tapaMaterial" Type="string"/>
                                <ext:RecordField Name="techo" Type="Boolean"/>                       
                            </Fields>
                        </ext:JsonReader>
                    </Reader>
                </ext:Store>
                </Store>
                <Plugins>
                <ext:RowEditor ID="RowEditor2" runat="server" SaveText="Update">
                                <Listeners>
                                <AfterEdit Handler="alerta();" />
                                </Listeners>
                </ext:RowEditor> 
                </Plugins>
            <View>
                <ext:GridView ID="GridView2" runat="server" MarkDirty="false" />
            </View>
           
             <SelectionModel>
                <ext:RowSelectionModel ID="RowSelectionModel3" runat="server" />
            </SelectionModel>
                <ColumnModel ID="ColumnModel4" runat="server">
                <Columns>
                <ext:RowNumbererColumn />
                <ext:Column ColumnID="buzon" DataIndex="buzon" runat="server" Header="Buzón" Width="90px">
                <%--<Editor>
                <ext:TextField ID="Txt9" runat="server" AllowBlank="true" />
                </Editor>--%>
                </ext:Column>
                <ext:NumberColumn ColumnID="profundidad" DataIndex="profundidad" runat="server" Header="Profundiad" Width="90px">
                <Editor>
                <ext:NumberField ID="nf9" runat="server" AllowBlank="true"  ReadOnly="true" AllowDecimals="true" DecimalSeparator="."/>
                </Editor>
                </ext:NumberColumn>
                <ext:Column ColumnID="marcoMaterial" DataIndex="marcoMaterial" runat="server" Header="Marco Material" Width="80px">
                <Editor>
                <ext:ComboBox 
                ID="ComboBox4" 
                runat="server" 
                Editable="false" Enabled="false"
                SelectOnFocus="true" Width="100px"
                EmptyText="Seleccione...">
                <Listeners>
                <Select Handler="" />
                </Listeners>        
                <Items>
                <ext:ListItem Text="fo.fo" Value="fo.fo" />
                <ext:ListItem Text="Concreto" Value="Concreto" />
                <ext:ListItem Text="Otros" Value="Otros" />
                </Items>
                </ext:ComboBox></Editor>
                </ext:Column>
                <ext:BooleanColumn ColumnID="marcoEstado" TrueText="Bueno" FalseText="Malo" DataIndex="marcoEstado" runat="server" Header="Marco Estado" Width="75px">
                <Editor>
                <ext:Checkbox ID="chkMestado" runat="server"  />
                </Editor>
                </ext:BooleanColumn>
                <ext:Column ColumnID="tapaMaterial" DataIndex="tapaMaterial" runat="server" Header="Tapa Material" Width="75px">
                <Editor>
                <ext:ComboBox 
                ID="ComboBox5" 
                runat="server" 
                Editable="false" Enabled="false"
                SelectOnFocus="true" Width="100px"
                EmptyText="Seleccione...">
                <Listeners>
                <Select Handler="" />
                </Listeners>        
                <Items>
                <ext:ListItem Text="fo.fo" Value="fo.fo" />
                <ext:ListItem Text="Concreto" Value="Concreto" />
                <ext:ListItem Text="Otros" Value="Otros" />
                </Items>
                </ext:ComboBox></Editor>
                </ext:Column>
                <ext:Column ColumnID="tapaEstado"  DataIndex="tapaEstado" runat="server" Header="Tapa Estado" Width="75px">
                <Editor>
                <ext:ComboBox 
                ID="ComboBox6" 
                runat="server" 
                Editable="false" Enabled="false"
                SelectOnFocus="true" Width="100px"
                EmptyText="Seleccione...">
                <Listeners>
                <Select Handler="" />
                </Listeners>        
                <Items>
                <ext:ListItem Text="Bueno" Value="bueno" />
                <ext:ListItem Text="Malo" Value="malo" />
                <ext:ListItem Text="No Tiene" Value="notiene" />
                </Items>
                </ext:ComboBox></Editor>
                </ext:Column>
                <ext:BooleanColumn ColumnID="solado" TrueText="Bueno" FalseText="Malo" DataIndex="solado" runat="server" Header="Solado" Width="45px">
                 <Editor>
                <ext:Checkbox ID="Checkbox3" runat="server" />
                </Editor>
                </ext:BooleanColumn>
                <ext:BooleanColumn ColumnID="media" TrueText="Bueno" FalseText="Reparar" DataIndex="media" runat="server" Header="Media" Width="45px">
                 <Editor>
                <ext:Checkbox ID="Checkbox4" runat="server" />
                </Editor>
                </ext:BooleanColumn>
                <ext:BooleanColumn ColumnID="cuerpo"  TrueText="Bueno" FalseText="Reparar" DataIndex="cuerpo" runat="server" Header="Cuerpo" Width="45px">
                 <Editor>
                <ext:Checkbox ID="Checkbox5" runat="server" />
                </Editor>
                </ext:BooleanColumn>
                <ext:BooleanColumn ColumnID="techo" TrueText="Bueno" FalseText="Reparar" DataIndex="techo" runat="server" Header="Techo" Width="45px">
                 <Editor>
                <ext:Checkbox ID="Checkbox6" runat="server"  />
                </Editor>
                </ext:BooleanColumn>
                <ext:BooleanColumn ColumnID="emboquillado"  TrueText="Bueno" FalseText="Reparar" DataIndex="emboquillado" runat="server" Header="Emboquill. de tub. buzn" Width="130px">
                 <Editor>
                <ext:Checkbox ID="Checkbox7" runat="server"  />
                </Editor>
                </ext:BooleanColumn>
                <ext:BooleanColumn ColumnID="sellado" TrueText="Bueno" FalseText="Reparar" DataIndex="sellado" runat="server" Header="Sellado boca tub luz" Width="120px">
                 <Editor>
                <ext:Checkbox ID="Checkbox8" runat="server" />
                </Editor>
                </ext:BooleanColumn>
                <ext:BooleanColumn ColumnID="marcoNivelado" TrueText="SI" FalseText="NO" DataIndex="marcoNivelado" runat="server" Header="Marco y tapa nivelado?" Width="135px">
                 <Editor>
                <ext:Checkbox ID="Checkbox9" runat="server" />
                </Editor>
                </ext:BooleanColumn>
                </Columns>
                </ColumnModel>
                <LoadMask ShowMask="true"/>
                </ext:GridPanel>
                            </Content>
                    </ext:Panel>
        <ext:Panel 
                        ID="Panel6"
                        runat="server" 
                        Title="4. Limpieza Colector" 
                        AutoHeight="true"
                        BodyPadding="6" Visible=false>
                            
                            <Content>
                            <ext:Panel Id="pan123" runat="server">
                                   
                            <Content>
                            
                            <div style="width:250px; height:100px; float:left; padding:0px 0px 10px 10px; margin-top:5px; font : normal 11px tahoma, arial, verdana;" >
                 <div>
                 <ext:Button ID="btnGuardar" Icon="Add" Width="50px" Text="Guardar" runat="server">
                                <Listeners>
								 <Click Fn="ModificaLimpieza"  />
    							</Listeners>
                                </ext:Button>
                 </div>
                 <div style="margin-top:20px;">
                    
                 <div style="width:100px; float:left;">Longitud del tramo</div> 
                 <div style=" float:left; width:110px;">
                 <ext:TextField runat="server" ID="longitud" DataIndex="longitud" Width="90px"></ext:TextField>
                 </div>
                 <br />
                 <br />
                 <div style="float: left; width:100px; padding-top:10px;">
                 Vol. extraído  
                 </div>
                 <div style="float:left; width:55px; padding-top:10px;">
                 <ext:TextField runat="server" ID="VolExtraido" DataIndex="VolExtraido" Width="50px"/>
                 </div>
                 <div style="float:left; margin-left:2px; padding-top:10px;">M3</div>
                 <br />
                 <br />
                <div style="float:left; width:100px; padding-top:10px;">
                Diámetro 
                </div>
                <div style="float:left; width:100px; padding-top:10px;">
                <ext:TextField runat="server" ID="Diametro" DataIndex="Diametro" Width="80px"></ext:TextField>
                </div>
                </div>
                </div>
                            <div style="width:250px; height:100px; float:left; padding:40px  5px 10px 0px; font : normal 11px tahoma, arial, verdana;">
                <div style="Float:left; width:100px;">
                Fecha de Ejecución   
                </div>
                <div style="float:left;">
                <ext:DateField 
                    ID="dfFechaEj" 
                    runat="server" DataIndex="dfFechaEj"
                    Vtype="daterange"
                    EnableKeyEvents="true" width="100px" Editable="true">  
                    <CustomConfig>
                        <ext:ConfigItem Name="endDateField" Value="DateField2" Mode="Value" />
                    </CustomConfig>
                    <Listeners>
                        <KeyUp Fn="onKeyUp" />
                    </Listeners>
                </ext:DateField>
                </div>
                <br />
                <br />
                <div style="float:left; width:100px; padding-top:10px;">
                Hora Inicio
                </div>
                <div style="float:left; padding-top:10px; width:40px">
                <%-- <ext:NumberField ID="horaI" runat="server" Width="35px" Vtype="alphanum"></ext:NumberField>--%>
                <ext:TextField ID="horaI1" runat="server" Width="35px" MaxLength="2"></ext:TextField>
                </div>
                <div style="float:left; padding-top:10px; width:5px">:
                </div>
                <div style="float:left; padding-top:10px; width:40px">
                <%-- <ext:NumberField ID="minutoI" runat="server" Width="35px" Vtype="alphanum" MaxLength="2"></ext:NumberField>--%>
                <ext:TextField ID="minutoI1" runat="server" Width="35px" MaxLength="2"></ext:TextField>
                </div>
                <br />
                <br />
                <div style="float:left; width:100px; padding-top:10px;">
                Hora Fin
                </div>              
                <div style="float:left; padding-top:10px; width:40px">
                <%-- <ext:NumberField ID="horaF" runat="server" Width="35px" Vtype="alphanum" MaxLength="2"></ext:NumberField>--%>
                <ext:TextField ID="horaF1" runat="server" Width="35px" MaxLength="2"></ext:TextField>
                </div>
                <div style="float:left; padding-top:10px; width:5px">:
                </div>
                <div style="float:left; padding-top:10px; width:40px">
                <%-- <ext:NumberField ID="minutoF" runat="server" Width="35px" Vtype="alphanum"></ext:NumberField>--%>
                <ext:TextField ID="minutoF1" runat="server" Width="35px" MaxLength="2" ></ext:TextField>
                </div>

          </div>
                            <div style="width:350px; height:100px; float:left; padding:40px 0px 10px 0px; font : normal 11px tahoma, arial, verdana;">
                <div style="float:left; width:50px;">
                Cuadrilla 
                </div>
                <div style="float:left;">
                 <ext:ComboBox ID="cbCuadrilla" runat="server" DataIndex="cbCuadrilla" DisplayField="Descripcion" ValueField="IdCuadrilla" Width="250px" ItemSelector="div.list-item"
                            Editable="true" 
							TypeAhead="true" 
							Mode="Local" 
							ForceSelection="true" 
							TriggerAction="All" 
                            >
								<Store>
									<ext:Store ID="storeCargaCuadrilla" runat="server">
										<Reader>
											<ext:JsonReader IDProperty="IdCuadrilla">
												<Fields>
													<ext:RecordField Name="IdCuadrilla" />
													<ext:RecordField Name="Descripcion" />
													<ext:RecordField Name="DetalleZona" />
													<ext:RecordField Name="NombresApellidos" />
												</Fields>
											</ext:JsonReader>
										</Reader>
									</ext:Store>
								</Store>
								<Template ID="Template3" runat="server">
									<Html>
										<tpl for=".">
											<div class="list-item">
												<b>{Descripcion}</b><br />{NombresApellidos}<br />{DetalleZona}
											</div>
										</tpl>
									</Html>
								</Template>
							</ext:ComboBox>
                </div>
              <br />
              <br />
                <div style="float:left; width:120px; padding-top:10px;">
                Material del tubo 
                </div>
                <div style="float:left; padding-top:10px;">
                <ext:ComboBox 
               ID="cbMatTubo" DataIndex="cbMatTubo" 
               runat="server" 
               Editable="false" 
               SelectOnFocus="true" Width="180px"
               EmptyText="Seleccione...">
               <Listeners>
               <Select Handler="" />
               </Listeners>        
                <Items>
                <ext:ListItem Text="PVC" Value="PVC" />
                <ext:ListItem Text="Concreto Simple Normaliza" Value="Concreto Simple Normaliza" />
                <ext:ListItem Text="Fierro Fundido" Value="Fierro Fundido" />
                <ext:ListItem Text="Polietileno" Value="Polietileno" />
                </Items>
                </ext:ComboBox>
                </div>
              <br />
              <br />
                <div style="float:left; width:150px; padding-top:10px;">    
                Tirante del flujo en el tramo 
                </div>
                <div style="float:left; padding-top:10px;">
                <ext:TextField runat="server" ID="Tirante" DataIndex="Tirante" Width="100px"></ext:TextField>
                </div>

                
          </div>
                            <div style="width:200px; height:170px; float:left; padding:10px 0px 5px 0px; font : normal 11px tahoma, arial, verdana;">
                            <table border="1" >
                <tr>
                <td style="padding:5px;">
                Sedimento:
                </td>
                </tr>
                <tr>
                <td style="padding:5px;">
                <div style="float:left; width:45px;">
                Arena 
                </div>
                <div style="float:left; margin-left:40px;">
                <ext:Checkbox ID="ckArena" Name="cbfofo" runat="server"  />
                </div>
                </td>
                </tr>
                <tr>
                <td style="padding:5px;">
                <div style="float:left; width:45px;">
                Piedras 
                </div>
                <div style="float:left; margin-left:40px;">
                <ext:Checkbox ID="ckPiedra" Name="cbfofo" runat="server" />
                </div>
                </td>
                </tr>
                <tr>
                <td style="padding:5px;">
                <div style="float:left; width:45px;">
                Cascajos 
                </div>
                <div style="float:left; margin-left:40px;">
                <ext:Checkbox ID="ckCascajos" Name="cbfofo" runat="server" />
                </div>
                </td>
                </tr>
                <tr>
                <td style="padding-top:5px; padding-left:5px; padding-right:5px; padding-bottom:0px;">
                <div style="float:left; width:45px;">
                Otros
                </div>
                <div style="float:left; margin-left:10px; width:20px; height:10px;">
                <ext:Checkbox ID="ckOtros" Name="cbfofo" runat="server" />
                </div>
                <div style="float:left;">
                <ext:TextField ID="txtotros" runat="server" Width="100px"></ext:TextField> </div>
                </td>
                </tr>
                </table>
                            </div>
                               
                        </Content>
                        </ext:Panel>

                            </Content>
                    </ext:Panel>
        <ext:Panel 
                        ID="Panel7"
                        runat="server" 
                        Title="5. Inspeccion Televisada" 
                        AutoHeight="true"
                        BodyPadding="6" Visible=false>
                            <Content>
                            <div style="width:370px; height:200px; float:left; font : normal 11px tahoma, arial, verdana;">
          <ext:GridPanel 
                ID="GridPanel3" 
                runat="server" 
                Title="Conexiones" 
                Height="200px"
                width="350px">
                <Store>
                <ext:Store ID="storeConexiones" runat="server">
                    <Reader>
                        <ext:JsonReader>
                            <Fields>
                                <ext:RecordField Name="pulgadas" Mapping="pulgadas" Type="Float" />
                                <ext:RecordField Name="distancia" Mapping="distancia" Type="Float" />
                                <ext:RecordField Name="izqDer" Mapping="izqDer" Type="String" />
                                <ext:RecordField Name="tipoMaterial" Mapping="tipoMaterial" Type="String" />
                                <ext:RecordField Name="IdCabecera" />
                                <ext:RecordField Name="IdConexiones" />
                            </Fields>
                        </ext:JsonReader>
                    </Reader>
                </ext:Store>
            </Store>
                <Plugins>
                <ext:RowEditor ID="RowEditor1" runat="server" SaveText="Update" >
                <Listeners>
                <AfterEdit Handler="ModificarConexion();" />
                </Listeners>
                </ext:RowEditor>
            </Plugins>
            <View>
                <ext:GridView ID="GridView1" runat="server" MarkDirty="false" />
            </View>
           <TopBar>
                <ext:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <ext:Button ID="Button1" runat="server" Text="Agregar Conexión" Icon="Add">
                            <Listeners>
                                <Click Fn="addEmployee" />
                            </Listeners>
                        </ext:Button>
                        <ext:Button ID="Button3" runat="server" Text="Eliminar Conexión" Icon="Delete">
                            <Listeners>
                                <Click Fn="removeEmployee" />
                            </Listeners>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </TopBar>
             <SelectionModel>
                <ext:RowSelectionModel ID="RowSelectionModel2" runat="server" />
            </SelectionModel>

               <ColumnModel ID="co" runat="server">
               <Columns>
               <ext:RowNumbererColumn />
               <ext:NumberColumn ColumnID="pulgadas" runat="server" DataIndex="pulgadas" Editable="true"  Header="06''" Width="35px">
               <Editor>
               <ext:NumberField ID="nf" runat="server" AllowBlank="false" Vtype="alphanum" />
               </Editor>
               </ext:NumberColumn>
               <ext:NumberColumn ColumnID="distancia" runat="server" DataIndex="distancia" Header="Distancia" Width="100px">
               <Editor>
               <ext:NumberField ID="nf2" runat="server" AllowBlank="false" AllowDecimals="true" DecimalSeparator="." />
               </Editor>
               </ext:NumberColumn>
               <ext:Column ColumnID="izqDer" runat="server" DataIndex="izqDer" Header="Der(D) - Izq(I)" Width="85px">
               <Editor>
               <ext:ComboBox 
               ID="ComboBox2" 
               runat="server" 
               SelectOnFocus="true" Width="100px"
               EmptyText="Seleccione...">
               <Listeners>
               <Select Handler="" />
               </Listeners>        
               <Items>
               <ext:ListItem Text="I" Value="I" />
               <ext:ListItem Text="D" Value="D" />
               </Items>
               </ext:ComboBox>
               </Editor>
               </ext:Column>
               <ext:Column ColumnID="tipoMaterial" runat="server" DataIndex="tipoMaterial" Header="Tipo Material" Width="85px">
               <Editor>
               <ext:TextField ID="TextField8" runat="server" AllowBlank="false" />
               </Editor>
               </ext:Column>
               </Columns>
               </ColumnModel>
               </ext:GridPanel> 
          </div>
                            <div style="width:370px; height:200px; float:left;padding-left:10px; font : normal 11px tahoma, arial, verdana;">
                <ext:GridPanel 
                ID="GridPanel4" 
                runat="server" 
                Title="Deficiencias Técnicas del Tramo" 
                Height="200" Width="350px" >
                <Store>
                <ext:Store ID="storeDeficiencias" runat="server">
                    <Reader>
                        <ext:JsonReader>
                            <Fields>
                                <ext:RecordField Name="codigo" Mapping="codigo" Type="Int" />
                                <ext:RecordField Name="distancia" Mapping="distancia" Type="Float" />
                                <ext:RecordField Name="puntual" Mapping="puntual" Type="Boolean" />
                                <ext:RecordField Name="extendida" Mapping="extendida" Type="Float" />
                                <ext:RecordField Name="IdCabecera" />
                                <ext:RecordField Name="IdDeficiencias" />
                            </Fields>
                        </ext:JsonReader>
                    </Reader>
                </ext:Store>
                </Store>
                <Plugins>
                <ext:RowEditor ID="RowEditor3" runat="server" SaveText="Update" >
                <Listeners>
                                <AfterEdit Handler="ModificarDeficiencia();" />
                                </Listeners>
                                </ext:RowEditor>
            </Plugins>
            <View>
                <ext:GridView ID="GridView3" runat="server" MarkDirty="false" />
            </View>
           <TopBar>
                <ext:Toolbar ID="Toolbar2" runat="server">
                    <Items>
                        <ext:Button ID="Button4" runat="server" Text="Agregar Deficiencias" Icon="Add">
                            <Listeners>
                                <Click Fn="addDeficiencias" />
                            </Listeners>
                        </ext:Button>
                        <ext:Button ID="Button5" runat="server" Text="Eliminar Deficiencias" Icon="Delete">
                            <Listeners>
                                <Click Fn="removeDeficiencias" />
                            </Listeners>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </TopBar>
            <SelectionModel>
                <ext:RowSelectionModel ID="RowSelectionModel4" runat="server" />
            </SelectionModel>

                <ColumnModel ID="ColumnModel5" runat="server">
                <Columns>
                <ext:RowNumbererColumn />
                <ext:NumberColumn ColumnID="codigo" DataIndex="codigo" runat="server" Header="cod" Width="60px">
                <Editor>
                <ext:NumberField ID="txtNum" runat="server" AllowBlank="false" Vtype="alphanum" />
                </Editor>
                </ext:NumberColumn>
                <ext:NumberColumn ColumnID="distancia"  DataIndex="distancia" runat="server" Header="Distancia" Width="100px">
                <Editor>
                <ext:NumberField ID="TextField4" runat="server" AllowBlank="false" AllowDecimals="true" DecimalSeparator="."/>
                <%-- <ext:TextField ID="TextFiel4" runat="server" AllowBlank="false" Vtype= />--%>
                </Editor>
                </ext:NumberColumn>
                <ext:BooleanColumn ColumnID="puntual"  DataIndex="puntual" runat="server" Header="Puntual" Width="60px">
                <Editor>
                <ext:Checkbox ID="Checkbox1" runat="server"  />
                </Editor>
                </ext:BooleanColumn>
                <ext:NumberColumn ColumnID="extendida"  DataIndex="extendida" runat="server" Header="Extendida ML" Width="80px">
                <Editor>
                <ext:NumberField ID="TextField51" runat="server" AllowBlank="false" Width="80px" AllowDecimals="true" DecimalSeparator="." />
                </Editor>
                </ext:NumberColumn>
                </Columns>
                </ColumnModel>
                </ext:GridPanel> 
          </div>
                            <div style="float:left; width:230px;margin-left:10px; font : normal 11px tahoma, arial, verdana;">
              <div style="float:left; width:30px;">
                            <ext:Button ID="btnGuarda" Icon="Add" runat="server" Text="Agregar" >
                              <Listeners>
								 <Click Fn="ModificaInspeccion"  />
    							</Listeners>
                            </ext:Button>
                            </div>
                  <div style="margin-top:30px; font : normal 11px tahoma, arial, verdana;">
                  
              <div style="float:left; width:120px;">
              Estado General del Tramo
              </div>
              <div style="margin-left:50px;">
              <ext:ComboBox 
                ID="cbEstado" 
                runat="server" 
                Editable="false" 
                SelectOnFocus="true" Width="100px"
                EmptyText="Seleccione...">
                <Listeners>
                    <Select Handler="" />
                </Listeners>        
                <Items>
                    <ext:ListItem Text="Bueno" Value="B" />
                    <ext:ListItem Text="Regular" Value="R" />
                    <ext:ListItem Text="Malo" Value="M" />
                </Items>
              </ext:ComboBox>
              </div>

              <br />
              <div style="float:left; width:120px;">
              Cuadrilla 
              </div>
              <div style="float:left;">
                <ext:ComboBox ID="cbCuadrillaInsp" runat="server" DataIndex="cbCuadrillaInsp" DisplayField="Descripcion" ValueField="IdCuadrilla" Width="220px" ItemSelector="div.list-item"
                            Editable="true" 
							TypeAhead="true" 
							Mode="Local" 
                            AllowBlank="true"
							ForceSelection="true" 
							TriggerAction="All" 
                            >
								<Store>
									<ext:Store ID="StorecuadrillaInspeccion" runat="server">
										<Reader>
											<ext:JsonReader IDProperty="IdCuadrilla">
												<Fields>
													<ext:RecordField Name="IdCuadrilla" />
													<ext:RecordField Name="Descripcion" />
													<ext:RecordField Name="DetalleZona" />
													<ext:RecordField Name="NombresApellidos" />
												</Fields>
											</ext:JsonReader>
										</Reader>
									</ext:Store>
								</Store>
								<Template ID="Template4" runat="server">
									<Html>
										<tpl for=".">
											<div class="list-item">
												<b>{Descripcion}</b><br />{NombresApellidos}<br />{DetalleZona}
											</div>
										</tpl>
									</Html>
								</Template>
							</ext:ComboBox>
                </div>
              <br />
              <div style="float:left; padding-top:10px; width:120px;">
              Hora Inicio
              </div>
              <div style="float:left; padding-top:10px; width:40px">
              <%--<ext:NumberField ID="hi" runat="server" Width="35px" AllowBlank="true" Vtype="alphanum"></ext:NumberField>--%>
              <ext:TextField ID="hi1" runat="server" Width="35px" AllowBlank="true" MaxLength="2"></ext:TextField>
              </div>
              <div style="float:left; padding-top:10px; width:5px">:
              </div>
              <div style="float:left; padding-top:10px; width:40px">
              <%--<ext:NumberField ID="mi" runat="server" Width="35px" AllowBlank="true" Vtype="alphanum"></ext:NumberField>--%>
              <ext:TextField ID="mi1" runat="server" Width="35px" AllowBlank="true" MaxLength="2"></ext:TextField>
              </div>
              <br />
              <div style="float:left; padding-top:10px; width:120px;">    
              Hora fin
              </div>
              <div style="float:left; padding-top:10px; width:40px">
              <%--<ext:NumberField ID="hf" runat="server" Width="35px" AllowBlank="true" Vtype="alphanum" ></ext:NumberField>--%>
              <ext:TextField ID="hf1" runat="server" Width="35px" AllowBlank="true" MaxLength="2"></ext:TextField>
              </div>
              <div style="float:left; padding-top:10px; width:5px">:
              </div>
              <div style="float:left; padding-top:10px; width:40px">
              <%--<ext:NumberField ID="mf" runat="server" Width="35px" AllowBlank="true" Vtype="alphanum"></ext:NumberField>--%>
              <ext:TextField ID="mf1" runat="server" Width="35px" AllowBlank="true" MaxLength="2"></ext:TextField>
              </div>
              <br />
              <div style="float:left; padding-top:10px; width:120px;">    
              Fecha
              </div>
              <div style="float:left; padding-top:10px;">
              <ext:DateField 
                    ID="dfFecha" 
                    runat="server" Editable="true"
                    Vtype="daterange" AllowBlank="true"
                    EnableKeyEvents="true" width="100px">  
                    <CustomConfig>
                        <ext:ConfigItem Name="endDateField" Value="DateField2" Mode="Value" />
                    </CustomConfig>
                    <Listeners>
                        <KeyUp Fn="onKeyUp" />
                    </Listeners>
              </ext:DateField>
              </div>
              </div>
          </div>
                            
                            </Content>
                    </ext:Panel>
        <ext:Panel 
                        ID="Panel8"
                        runat="server" 
                        Title="6. Purga" 
                        AutoHeight="true"
                        BodyPadding="6" Visible=false>
                            <Content>
                            
                            <div style="width:380px; height:200px; float:left;  font : normal 11px tahoma, arial, verdana;">
                                <div >
                                <table>
                                    <tr>
                                        <td><ext:Button ID="btnGuardarPurga" Icon="Add" Width="70px" Text="Guardar" runat="server">
                                <Listeners>
								 <Click Fn="GuardarPurga"  />
    							</Listeners>
                                </ext:Button>
                                        </td>
                                        <td><ext:Button ID="btnCancelarPurga" Icon="Cross" Width="70px" Text="Cancelar" runat="server">
                                <DirectEvents>
									    <Click OnEvent="btnCancelarPurga_Click"></Click>
								</DirectEvents>
                                </ext:Button>
                                        </td>
                                    </tr>
                                </table>
                                </div>
                                <div >
                                <table>
                                <tr style="height:40px;">
                                <td>Sector</td>
                                <td>
                                <ext:TextField ID="Sector" runat="server" Width="70px" Vtype="alphanum" AllowBlank="false"/>
                                </td>
                                <td>Cloro (PPM)</td>
                                <td>
                                <ext:TextField ID="Cloro" runat="server" Width="70px" AllowBlank="false"/>
                                </td>
                                </tr>
                                <tr style="height:40px;">
                                <td>Tiempo Purga(min)</td>
                                <td><ext:TextField ID="Tpurga" runat="server" Width="70px" AllowBlank="false"/></td>
                                <td>ANF (m3)</td>
                                <td>
                                <ext:TextField ID="ANF" runat="server" Width="70px" AllowBlank="false"/>
                                </td>
                                </tr>
                                <tr style="height:40px;">
                                <td>Presión (PSI)</td>
                                <td><ext:TextField ID="Presion" runat="server" Width="70px" AllowBlank="false"/></td>
                                <td>Caracteristica del Agua</td>
                                <td> 
                                <ext:ComboBox ID="cbCaractAgua" runat="server" 
                                Editable="false" SelectOnFocus="true" Width="70px"
                                EmptyText="Seleccione...">
                                <Listeners>
                                <Select Handler="" />
                                </Listeners>        
                                <Items>
                                <ext:ListItem Text="L" Value="L" />
                                <ext:ListItem Text="T" Value="T" />
                                <ext:ListItem Text="S" Value="S" />
                                </Items>
                                </ext:ComboBox>             
                                </td>
                                </tr>
                                </table>
                                </div>
                            </div>
                            <div style="width:310px; height:200px; float:left;padding-left:10px; font : normal 11px tahoma, arial, verdana;">
                                <table style="margin-top:20px;">
                                <tr style="height:40px;">
                                <td>Op. - Inop.</td>
                                <td>
                                <ext:Store  ID="CitiesStore" runat="server" AutoLoad="false" OnRefreshData="CitiesRefresh">
                                    <DirectEventConfig>
                                        <EventMask ShowMask="false" />
                                    </DirectEventConfig>
                                    <Reader>
                                        <ext:JsonReader IDProperty="Id">
                                            <Fields>
                                                <ext:RecordField Name="id" Type="String" Mapping="Id" />
                                                <ext:RecordField Name="name" Type="String" Mapping="Name" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                    <Listeners>
                                        <Load Handler="#{Cities}.setValue(#{Cities}.store.getAt(0).get('id'));" />
                                    </Listeners>
                                </ext:Store>
                                <ext:ComboBox ID="Countries" runat="server" Editable="false" Width="100px"
                                TypeAhead="true" Mode="Local" ForceSelection="true" TriggerAction="All" 
                                SelectOnFocus="true" EmptyText="Seleccione...">
                                    <Listeners>
                                        <Select Handler="#{Cities}.clearValue(); #{CitiesStore}.reload();" />
                                    </Listeners>        
                                    <Items>
                                        <ext:ListItem Text="Operativo" Value="Operativo" />
                                        <ext:ListItem Text="Inoperativo" Value="Inoperativo" />
                                    </Items>
                                </ext:ComboBox>
                                </td>
                                <td>N° Bocas</td>
                                <td>
                                <ext:TextField ID="nroBocas" runat="server" Width="70px" Vtype="alphanum" AllowBlank="false"/>
                                </td>
                                </tr>
                                <tr style="height:40px;">
                                <td> </td>
                                <td>

                                <ext:ComboBox 
                                ID="Cities" 
                                runat="server" Width="100px" Editable="false"
                                StoreID="CitiesStore" 
                                TypeAhead="true" 
                                Mode="Local"
                                ForceSelection="true" 
                                TriggerAction="All" 
                                DisplayField="name" 
                                ValueField="id"
                                EmptyText="Cargando..." 
                                ValueNotFoundText="Cargando..."
                                />                      
                                </td>
                                <td>N° Tapas</td>
                                <td>
                                <ext:TextField ID="nroTapas" runat="server" Width="70px" Vtype="alphanum" AllowBlank="false"/>
                                </td>
                                </tr>
                                <tr style="height:40px;">
                                <td>Marca</td>
                                <td><ext:TextField ID="marca" runat="server" Width="100px" AllowBlank="false"/></td>
                                <td>GCI Cuerpo</td>
                                <td> 
                                <ext:ComboBox ID="cbCGI" runat="server" 
                                Editable="false" SelectOnFocus="true" Width="70px"
                                EmptyText="Seleccione...">
                                <Listeners>
                                <Select Handler="" />
                                </Listeners>        
                                <Items>
                                <ext:ListItem Text="S" Value="S" />
                                <ext:ListItem Text="H" Value="H" />
                                </Items>
                                </ext:ComboBox>             
                                </td>
                                </tr>
                                </table>
                            </div>
                            <div style="float:left; width:195px;margin-left:10px; font : normal 11px tahoma, arial, verdana;">
                                <div style="margin-top:30px;">
                                <ext:Checkbox ID="ckUbica" runat="server" FieldLabel="Se ubica" >
                                <Listeners>
                                <Check fn="MuestraPanel"/>
                                </Listeners>
                                </ext:Checkbox>

                                </div>
                                <ext:Panel id="panUbica" runat="server">
                                <Content>
                                    <table>
                                        <tr>
                                        <td><ext:Checkbox ID="ckMyT" BoxLabel="Sin M y T" runat="server"></ext:Checkbox></td>
                                        <td><ext:Checkbox ID="ckLosa" BoxLabel="Losa Deteriorada" runat="server"></ext:Checkbox></td>
                                        </tr>
                                        <tr>
                                        <td>Mantenimiento</td>
                                        <td>
                                        <ext:RadioGroup ID="RadioGroup3" 
                                        runat="server" 
                                        FieldLabel="" 
                                        ColumnsNumber="2">
                                        <Items>
                                            <ext:Radio ID="rbsi"
                                                       Name="rbsi" runat="server" BoxLabel="SI">
                                            </ext:Radio>
                                            <ext:Radio ID="rbno" 
                                                       Name="rbno" runat="server" BoxLabel="NO">
                                            </ext:Radio>
                                        </Items>
                                        </ext:RadioGroup> 
                                        </td>
                                        </tr>
                                    </table>
                                </Content>
                                </ext:Panel>
                                <div>
                                    <table>
                                        <tr>
                                            <td>
                                            Observaciones
                                            </td>
                                            <td>
                                            <ext:TextArea ID="taObs" runat="server" AllowBlank="false"/>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div style="float:left; margin-left:10px; width:190px; font : normal 11px tahoma, arial, verdana;">
                                <div style="margin-top:30px;">
                                <table>
                                    <tr style="height:40px;">
                                        <td>Color de Agua</td>
                                        <td><ext:ComboBox ID="cbColorAgua" runat="server" 
                                Editable="false" SelectOnFocus="true" Width="70px"
                                EmptyText="Seleccione...">
                                <Listeners>
                                <Select Handler="" />
                                </Listeners>        
                                <Items>
                                <ext:ListItem Text="M" Value="M" />
                                <ext:ListItem Text="L" Value="L" />
                                <ext:ListItem Text="S" Value="S" />
                                </Items>
                                </ext:ComboBox> </td>
                                    </tr>
                                    <tr style="height:40px;">
                                        <td>Descarga En</td>
                                        <td><ext:ComboBox ID="cbDescarga" runat="server" 
                                Editable="false" SelectOnFocus="true" Width="70px"
                                EmptyText="Seleccione...">
                                <Listeners>
                                <Select Handler="" />
                                </Listeners>        
                                <Items>
                                <ext:ListItem Text="B" Value="B" />
                                <ext:ListItem Text="J" Value="J" />
                                <ext:ListItem Text="V" Value="V" />
                                <ext:ListItem Text="P" Value="P" />
                                </Items>
                                </ext:ComboBox> </td>
                                    </tr>
                                    <tr style="height:40px;">
                                        <td>Distancia</td>
                                        <td><ext:TextField ID="Distancia" runat="server" Width="70px" AllowBlank="false"/></td>
                                    </tr>
                                </table>
                                </div>
                            </div>
                            </Content>
                    </ext:Panel>
        <ext:Panel 
                        ID="Panel9"
                        runat="server" 
                        Title="7. Características" 
                        AutoHeight="true"
                        BodyPadding="6" Visible=false>
                            <Content>
                            <div style="width:350px; height:200px; float:left;  font : normal 11px tahoma, arial, verdana;">
                                <div >
                                <table>
                                    <tr>
                                        <td><ext:Button ID="btnGuardarCaracteristicas" Icon="Add" Width="70px" Text="Guardar" runat="server">
                                        <Listeners>
								        <Click Fn="GuardarCaracteristicas"  />
    							        </Listeners>
                                        </ext:Button>
                                        </td>
                                        <td><ext:Button ID="btnCancelarCarac" Icon="Cross" Width="70px" Text="Cancelar" runat="server">
                                        <DirectEvents>
									    <Click OnEvent="btnCancelarCarac_Click"></Click>
								        </DirectEvents>
                                        </ext:Button>
                                        </td>
                                    </tr>
                                </table>
                                </div>
                                <div >
                                <ext:Panel Title="Válvula" runat="server" ID="subPan">
                                <Content>
                                <table>
                                <tr style="height:30px;">
                                <td>N° Vueltas</td>
                                <td><ext:TextField ID="Nvueltas" runat="server" width="70px" Vtype="alphanum" AllowBlank="false"/></td>
                                <td colspan="2">
                                <ext:Panel ID="Panel10" runat="server">
                                <Items>
                                <ext:RadioGroup ID="RadioGroup2"  runat="server" ColumnsNumber="2" Width="100px">
                                <Items> 
                                <ext:Radio ID="rbIzq" runat="server" Width="40px" BoxLabel="Izq."/>
                                <ext:Radio ID="rbDer" runat="server" Width="40px" BoxLabel="Der." />
                                </Items>
                                </ext:RadioGroup>
                                </Items>
                                </ext:Panel>                                     
                                </td>
                                </tr >
                                <tr style="height:30px;">
                                <td>Nivel de Apertura</td>
                                <td>
                                <ext:TextField ID="NivApert" runat="server" Width="70px" Vtype="alphanum" AllowBlank="false"></ext:TextField>
                                </td>
                                <td>Estado Válvula</td>
                                <td>
                                <ext:ComboBox ID="cbEstValvul" runat="server" 
                                Editable="false" SelectOnFocus="true" Width="100px"
                                EmptyText="Seleccione...">
                                <Listeners>
                                <Select Handler="" />
                                </Listeners>        
                                <Items>
                                <ext:ListItem Text="Excelente" Value="Excelente" />
                                <ext:ListItem Text="Bueno" Value="Bueno" />
                                <ext:ListItem Text="Regular" Value="Regular" />
                                <ext:ListItem Text="Malo" Value="Malo" />
                                </Items>
                                </ext:ComboBox>
                                </td>
                                </tr>
                                <tr style="height:30px;">
                                <td >Marca</td>
                                <td colspan="3"><ext:TextField ID="marcaCar" runat="server" Width="180px" AllowBlank=false></ext:TextField></td>
                                </tr>
                                </table>
                                </Content>
                                </ext:Panel>
                                </div>
                            </div>
                            <div  style="width:355px; height:200px; margin-left:10px; float:left; margin-top:26px;  font : normal 11px tahoma, arial, verdana;">
                                <ext:Panel Title="Grifo" runat="server" ID="Panel11">
                                <Content>
                                <table>
                                <tr style="height:30px;">
                                <td>Diámetro</td>
                                <td>
                                <ext:ComboBox ID="cbDiametro" runat="server" 
                                Editable="false" SelectOnFocus="true" Width="70px"
                                EmptyText="Seleccione...">
                                <Listeners>
                                <Select Handler="" />
                                </Listeners>        
                                <Items>
                                <ext:ListItem Text="1/2''" Value="1/2''" />
                                <ext:ListItem Text="3/4''" Value="3/4''" />
                                <ext:ListItem Text="1''" Value="1''" />
                                <ext:ListItem Text="2''" Value="2''" />
                                <ext:ListItem Text="4''" Value="4''" />
                                <ext:ListItem Text="6''" Value="6''" />
                                <ext:ListItem Text="8''" Value="8''" />
                                </Items>
                                </ext:ComboBox>
                                </td>
                                <td>N° Bocas</td>
                                <td><ext:TextField ID="txtBocas" runat="server" Width="70px" Vtype="alphanum" AllowBlank="false"></ext:TextField></td>
                                </tr>
                                <tr style="height:30px;">
                                <td>Marca</td>
                                <td><ext:TextField ID="txtMarca" runat="server" AllowBlank="false"></ext:TextField></td>
                                <td>N° Vueltas</td>
                                <td>
                                <ext:TextField ID="txtVueltas" runat="server" Width="70px" Vtype="alphanum" AllowBlank="false"></ext:TextField>
                                </td>
                                </tr>
                                <tr style="height:30px;">
                                <td >Sector</td>
                                <td><ext:TextField ID="txtSec" runat="server" Width="70px" Vtype="alphanum" AllowBlank="false"></ext:TextField></td>
                                <td>N° Vueltas Abiertas</td>
                                <td><ext:TextField ID="txtVueltasAb" runat="server" Width="70px" Vtype="alphanum" AllowBlank="false"></ext:TextField></td>
                                </tr>
                                </table>
                                </Content>
                                </ext:Panel>
                                </div>
                            <div  style="width:360px; margin-left:10px; height:200px; float:left; margin-top:26px;  font : normal 11px tahoma, arial, verdana;">
                                <ext:Panel Title="Otros" runat="server" ID="Panel12">
                                <Content>
                                <table>
                                <tr style="height:30px;">
                                <td>Situación</td>
                                <td>
                                <ext:Panel ID="Panel14" runat="server">
                                <Items>
                                <ext:RadioGroup ID="RadioGroup5"  runat="server" ColumnsNumber="2" Width="130px">
                                <Items> 
                                <ext:Radio ID="rbOp" runat="server" Width="50px" BoxLabel="Ope."/>
                                <ext:Radio ID="rbInop" runat="server" Width="70px" BoxLabel="Inop." />
                                </Items>
                                </ext:RadioGroup>
                                </Items>
                                </ext:Panel> 
                                </td>
                                <td>N° tapas Boca masa</td>
                                <td><ext:TextField ID="txtNroTapBoc" runat="server" Width="70px" Vtype="alphanum" AllowBlank="false"></ext:TextField></td>
                                </tr>
                                <tr style="height:30px;">
                                <td>Cuerpo</td>
                                <td>
                                <ext:Panel ID="Panel13" runat="server">
                                <Items>
                                <ext:RadioGroup ID="RadioGroup4"  runat="server" ColumnsNumber="2" Width="140px">
                                <Items> 
                                <ext:Radio ID="rbseco" runat="server" Width="35px" BoxLabel="Seco"/>
                                <ext:Radio ID="rbHum" runat="server" Width="80px" BoxLabel="Húmedo" />
                                </Items>
                                </ext:RadioGroup>
                                </Items>
                                </ext:Panel> 
                                </td>
                                <td>Ubica</td>
                                <td>
                                <ext:ComboBox ID="cbOtrUbica" runat="server" 
                                Editable="false" SelectOnFocus="true" Width="70px"
                                EmptyText="Seleccione...">
                                <Listeners>
                                <Select Handler="" />
                                </Listeners>        
                                <Items>
                                <ext:ListItem Text="Jardín" Value="Jardín" />
                                <ext:ListItem Text="Tierra" Value="Tierra" />
                                <ext:ListItem Text="Pavimento" Value="Pavimento" />
                                <ext:ListItem Text="Vereda" Value="Vereda" />
                                </Items>
                                </ext:ComboBox>
                                </td>
                                </tr>
                                <tr style="height:30px;">
                                <td colspan="2">Ubicación de la Válvula del Grifo</td>
                                <td colspan="2">
                                <ext:ComboBox ID="cbOtrUbicaVal" runat="server" 
                                Editable="false" SelectOnFocus="true" Width="120px"
                                EmptyText="Seleccione...">
                                <Listeners>
                                <Select Handler="" />
                                </Listeners>        
                                <Items>
                                <ext:ListItem Text="Jardín" Value="Jardín" />
                                <ext:ListItem Text="Tierra" Value="Tierra" />
                                <ext:ListItem Text="Pavimento" Value="Pavimento" />
                                <ext:ListItem Text="Vereda" Value="Vereda" />
                                </Items>
                                </ext:ComboBox>
                                </td>
                                </tr>
                                </table>
                                </Content>
                                </ext:Panel>
                                </div>
                            </Content>
                    </ext:Panel>
                    <ext:Panel 
                        ID="Panel15"
                        runat="server" 
                        Title="3. Detalle Informe Parte Trabajo" 
                        Height="320px"
                        BodyPadding="6">
                            <Content>

                            <div style="float:left; width:300px;  margin-left:10px; font : normal 11px tahoma, arial, verdana;">
                            <ext:Panel ID="Panel17" runat="server" Title="Informacion del Especialista" Height="250px" Width="800px">
                            <Content>
                            <table>
                                <tr>
							       
							        <td style="padding-left:5px;" colspan="5">
								        <ext:TextArea ID="txtObservacion" runat="server" Width="750" Height="200">
								        </ext:TextArea>
							        </td>
						        </tr>
                                 </table>
                            </Content>
                            </ext:Panel>
                            </div>


                            <div style="float:left; width:300px; font : normal 11px tahoma, arial, verdana;">
                            <ext:Panel ID="PanelD1" runat="server" Title="D1" Visible=false>
                            <Content>    
                            <table>
                            <tr>
                            <td>Altura de sólidos en Buzón</td><ext:Hidden ID="HidOtros" runat="server"></ext:Hidden>
                            <td><ext:TextField ID="txtAltSolBuzon" runat="server" Width="70px"></ext:TextField></td>
                            <td>Diámetro Interno Buzón</td>
                            <td><ext:TextField ID="PulgIntBuzon" runat="server" Width="70px"></ext:TextField></td>
                            </tr>
                            <tr>
                            <td>Volúmen Extraído Sólidos</td>
                            <td><ext:TextField ID="txtVolExtSolido" runat="server" Width="70px"></ext:TextField></td>
                            <td>Tirante Hidráulico Flujo</td>
                            <td><ext:TextField ID="txtTirHidFlujo" runat="server" Width="70px"></ext:TextField></td>
                            </tr>
                            <tr>
                            <td>Diámetro del Colector</td>
                            <td><ext:TextField ID="txtDiamColector" runat="server" Vtype="alphanum" Width="70px"></ext:TextField></td>
                            <td>Altura de Agua Retenida</td>
                            <td><ext:TextField ID="txtAltAguaRet" runat="server" Width="70px"></ext:TextField></td>
                            </tr>
                            <tr>
                            <td>Altura total Buzón</td>
                            <td><ext:TextField ID="txtAltTotBuzon" runat="server" Width="70px"></ext:TextField></td>
                            <td>otros</td>
                            <td><ext:TextArea ID="taOtrosD1" runat="server"></ext:TextArea></td>
                            </tr>
                            <tr>
                            <td>Desmonte</td>
                            <td><ext:RadioGroup ID="RadioGroup6" 
                                        runat="server" 
                                        FieldLabel="" 
                                        ColumnsNumber="2">
                                        <Items>
                                            <ext:Radio ID="RbDesmontSi"
                                                       Name="rbDesmontesi" runat="server" BoxLabel="SI">
                                            </ext:Radio>
                                            <ext:Radio ID="RbDesmontNo" 
                                                       Name="rbDesmonteno" runat="server" BoxLabel="NO">
                                            </ext:Radio>
                                        </Items>
                                        </ext:RadioGroup> </td>
                                        <td>Con Agua</td>
                            <td><ext:RadioGroup ID="RadioGroup7" 
                                        runat="server" 
                                        FieldLabel="" 
                                        ColumnsNumber="2">
                                        <Items>
                                            <ext:Radio ID="RbAguaSi"
                                                       Name="rbaguasi" runat="server" BoxLabel="SI">
                                            </ext:Radio>
                                            <ext:Radio ID="RbAguaNo" 
                                                       Name="rbaguano" runat="server" BoxLabel="NO">
                                            </ext:Radio>
                                        </Items>
                                        </ext:RadioGroup> </td>
                            </tr>
                            <tr>
                            <td colspan="2"><ext:Button ID="btnGuardaD1" Icon="Add" runat="server" Text="Guardar D1">
                            <Listeners>
							<Click Fn="GuardarACtD1"  />
    						</Listeners>
                            </ext:Button></td>
                            <td colspan="2"><ext:Button ID="btnCancelarD1" Icon="Cross" runat="server" Text="Cancelar D1"></ext:Button></td>
                            </tr>
                            </table>
                            </Content>
                            </ext:Panel>
                            </div>

                            <div style="float:left; width:300px; margin-left:10px; font : normal 11px tahoma, arial, verdana;">
                            <ext:Panel ID="Panel16" runat="server" Title="Otra Actividad" Visible=false>
                            <Content>
                            <table>
                            <tr>
                            <td style="width:70px;">Nro. DVD</td>
                            <td><ext:TextField ID="txtDVD" runat="server" AllowBlank="false"></ext:TextField></td>
                            </tr>
                            <tr>
                            <td colspan="2"><ext:Button ID="Button6" Icon="Add" runat="server" Text="Guardar">
                            <Listeners>
							<Click Fn="GuardarDVD"  />
    						</Listeners>
                            </ext:Button></td>
                            <td colspan="2"><ext:Button ID="Button7" Icon="Cross" runat="server" Text="Cancelar"></ext:Button></td>
                            </tr>
                            </table>
                            </Content>
                            </ext:Panel>
                            </div>

                            </Content>
                    </ext:Panel>
        </Items>
        </ext:TabPanel>
		<%--VENTANAS POP-UP--%>

		<ext:Window 
            ID="Window2" 
            runat="server" 
            Icon="LinkAdd" 
            Title="Sub-Actividad" 
            Hidden="true" 
			Width="600px" AutoHeight="true"
         >
			<Content>
				<ext:Hidden ID="hdnIdSubAct" runat="server">
				</ext:Hidden>
				<table cellpadding="2" cellspacing="2">
					<tr>
						<td style="padding-left:5px;">Descripción</td>
						<td colspan="6" style="padding-left:5px;">
							<ext:ComboBox ID="ddlSubActDescripcion" runat="server" 
							DisplayField="DescripcionSubActividad1" 
							ValueField="IdSubActividad" 
							Editable="true" 
							TypeAhead="true" 
							Mode="Local"
							ForceSelection="true"
							TriggerAction="All"
							Width="500px">
								<Store>
									<ext:Store ID="StoreSubAct" runat="server">
										<Reader>
											<ext:JsonReader IDProperty="IdProCatalogo">
												<Fields>
													<ext:RecordField Name="IdSubActividad" />
													<ext:RecordField Name="DescripcionSubActividad1" />
													<ext:RecordField Name="Unidad" />
													<ext:RecordField Name="CostoProgramado" />
												</Fields>
											</ext:JsonReader>
										</Reader>
									</ext:Store>
								</Store>
                                <Listeners>
                                    <Select Handler="CargarUnidad(record.data.Unidad,record.data.CostoProgramado);" />
                                </Listeners>
							</ext:ComboBox>
						</td>
					</tr>
                    <tr>
						 <td style="padding-left:5px;">Unidad</td>
						    <td style="padding-left:5px;">
							    <ext:TextField ID="txtSubActUnidad" runat="server" Width="50" ReadOnly="true"/>
					     </td>
                         <td style="padding-left:5px;">Precio</td>
						    <td style="padding-left:5px;">
							    <ext:TextField ID="txtSubActPrecio" runat="server" Width="50" />
						 </td>
    					    <td style="padding-left:15px;">Cant.H</td>
						    <td style="padding-left:5px;">
							    <ext:TextField ID="txtSubActCantidad" runat="server" Width="50">
                                    <Listeners>
                                        <SpecialKey Fn="enterKeyPressHandler" />
                                    </Listeners>
                                </ext:TextField>
						    </td>
						    <td style="padding-left:15px;" width="250">
                            </td>
                    </tr>
				</table>
                 <tr>
                    <td style="padding-left:5px;">Observacion</td>
					<td style="padding-left:5px;">
						<ext:TextField ID="txtsubactobservacion" runat="server" Width="500" Height="40"/>
					</td>
                </tr>
			</Content>
			
		 </ext:Window>
		<ext:Window 
            ID="Window1" 
            runat="server" 
            Icon="LinkAdd" 
            Title="Material" 
            Hidden="true" 
			Width="600px" AutoHeight="true"
         >
			<Content>
			<ext:Hidden ID="hdnIdMaterial" runat="server">
				</ext:Hidden>
				<table cellpadding="2" cellspacing="2">
					<tr>
						<td style="padding-left:5px;">Descripción</td>
						<td colspan="6" style="padding-left:5px;">
							<ext:ComboBox ID="ddlMaterialDescripcion" runat="server" 
							DisplayField="Descripcion1" 
							ValueField="IdProCatalogo" 
							Editable="true" 
							TypeAhead="true" 
							Mode="Local"
							ForceSelection="true"
							TriggerAction="All"
							Width="500px">
								<Store>
									<ext:Store ID="StoreMaterial" runat="server">
										<Reader>
											<ext:JsonReader IDProperty="IdProCatalogo">
												<Fields>
													<ext:RecordField Name="IdProCatalogo" />
													<ext:RecordField Name="Descripcion1" />
													<ext:RecordField Name="Unidad" />
													<ext:RecordField Name="Precio" />
												</Fields>
											</ext:JsonReader>
										</Reader>
									</ext:Store>
								</Store>
                                <Listeners>
                                    <Select Handler="CargarMaterial(record.data.Unidad,record.data.Precio);" />
                                </Listeners>
							</ext:ComboBox>
						</td>
					</tr>
					<tr>
						<td style="padding-left:5px;">Unidad</td>
						<td style="padding-left:5px;">
							<ext:TextField ID="txtMaterialUnidad" runat="server" Width="50" ReadOnly="true"/>
						</td>
						<td style="padding-left:15px;">Precio</td>
						<td style="padding-left:5px;">
							<ext:TextField ID="txtMaterialPrecio" runat="server" Width="50" />
						</td>
						<td style="padding-left:15px;">Cantidad</td>
						<td style="padding-left:5px;">
							<ext:TextField ID="txtMaterialCantidad" runat="server" Width="50" >
                                <Listeners>
                                    <SpecialKey Fn="enterKeyPressHandler2" />
                                </Listeners>
                            </ext:TextField>
						</td>
						<td style="width:250px;"></td>
					</tr>
				</table>
                <tr>
                    <td style="padding-left:5px;">Observacion</td>
					<td style="padding-left:5px;">
						<ext:TextField ID="txtmaterialobservacion" runat="server" Width="500" Height="40"/>
					</td>
                </tr>
			</Content>
		 </ext:Window>
		<ext:Window 
            ID="Window4" 
            runat="server" 
            Icon="LinkAdd" 
            Title="Trabajo Complementario" 
            Hidden="true" 
			Width="600px" AutoHeight="true"
         >
			<Content>
			<ext:Hidden ID="hdnIdTC" runat="server">
				</ext:Hidden>
				<table cellpadding="2" cellspacing="2">
					<tr>
						<td style="padding-left:5px;">Descripción</td>
						<td colspan="6" style="padding-left:5px;">
							<ext:ComboBox ID="ddlTCDescripcion" runat="server" 
							DisplayField="DescripcionSubActividad1" 
							ValueField="IdSubActividad" 
							Editable="true" 
							TypeAhead="true" 
							Mode="Local" 
							ForceSelection="true" 
							TriggerAction="All" 
							Width="500px">
								<Store>
									<ext:Store ID="StoreTC" runat="server">
										<Reader>
											<ext:JsonReader IDProperty="IdSubActividad">
												<Fields>
													<ext:RecordField Name="IdSubActividad" />
													<ext:RecordField Name="DescripcionSubActividad1" />
													<ext:RecordField Name="Unidad" />
													<ext:RecordField Name="CostoProgramado" />
												</Fields>
											</ext:JsonReader>
										</Reader>
									</ext:Store>
								</Store>
                                <Listeners>
                                    <Select Handler="CargarTC(record.data.Unidad,record.data.CostoProgramado);" />
                                </Listeners>
							</ext:ComboBox>
						</td>
					</tr>
                    <tr>
                        <td style="padding-left:5px;">Ejecutor</td>
                        <td colspan="6" style="padding-left:5px;">
                            <ext:RadioGroup ID="RadioGroup1" runat="server" Width="200px">
                                <Items>
                                    <ext:Radio ID="rCuadrilla" runat="server" BoxLabel="Asignado" BoxLabelStyle="padding-right:15px;">
                                        <Listeners>
                                            <Check Fn="ManejarCuadrillaTC" />
                                        </Listeners>
                                    </ext:Radio>
									<ext:Radio ID="rProveedor" runat="server" BoxLabel="Proveedor" BoxLabelStyle="padding-right:15px;">
                                        <Listeners>
                                            <Check Fn="ManejarProveedorTC" />
                                        </Listeners>
                                    </ext:Radio>
                                </Items>
                            </ext:RadioGroup>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left:5px;">Nombre</td>
                        <td colspan="6" style="padding-left:5px;">
                            <ext:ComboBox ID="ddlTCCuadrilla" runat="server" DisplayField="Descripcion" ValueField="IdCuadrilla" Width="300px" ItemSelector="div.list-item"
                            Editable="true" 
							TypeAhead="true" 
							Mode="Local" 
							ForceSelection="true" 
							TriggerAction="All" 
                             Hidden="true"
                            >
								<Store>
									<ext:Store ID="StoreTCCuadrilla" runat="server">
										<Reader>
											<ext:JsonReader IDProperty="IdCuadrilla">
												<Fields>
													<ext:RecordField Name="IdCuadrilla" />
													<ext:RecordField Name="Descripcion" />
													<ext:RecordField Name="DetalleZona" />
													<ext:RecordField Name="NombresApellidos" />
												</Fields>
											</ext:JsonReader>
										</Reader>
									</ext:Store>
								</Store>
								<Template ID="Template12" runat="server">
									<Html>
										<tpl for=".">
											<div class="list-item">
												<b>{Descripcion}</b><br />{NombresApellidos}<br />{DetalleZona}
											</div>
										</tpl>
									</Html>
								</Template>
							</ext:ComboBox>
                            <ext:ComboBox ID="ddlTCProveedor" runat="server" 
								DisplayField="Proveedor" 
								ValueField="IdProveedor" 
								Editable="true" 
								TypeAhead="true" 
								Mode="Local"
								ForceSelection="true"
								TriggerAction="All"
								Width="300px" Hidden="true">
								<Store>
									<ext:Store ID="StoreTCProveedor" runat="server">
										<Reader>
											<ext:JsonReader IDProperty="IdProveedor">
												<Fields>
													<ext:RecordField Name="IdProveedor" />
													<ext:RecordField Name="Proveedor" />
												</Fields>
											</ext:JsonReader>
										</Reader>
									</ext:Store>
								</Store>
							</ext:ComboBox>
                        </td>
                    </tr>
					<tr>
						<td style="padding-left:5px;">Unidad</td>
						<td style="padding-left:5px;">
							<ext:TextField ID="txtTCUnidad" runat="server" Width="50" ReadOnly="true"/>
						</td>
						<td style="padding-left:15px;">Precio</td>
						<td style="padding-left:5px;">
							<ext:TextField ID="txtTCPrecio" runat="server" Width="50" />
						</td>
						<td style="padding-left:15px;">Cantidad Horas</td>
						<td style="padding-left:5px;">
							<ext:TextField ID="txtTCCantidad" runat="server" Width="50">
                                <Listeners>
                                    <SpecialKey Fn="enterKeyPressHandler3" />
                                </Listeners>
                            </ext:TextField>
						</td>
						<td style="width:250px;"></td>
					</tr>
				</table>
                 <tr>
                    <td style="padding-left:5px;">Observacion</td>
					<td style="padding-left:5px;">
						<ext:TextField ID="txtTCobservacion" runat="server" Width="500" Height="40" />
					</td>
                </tr>
			</Content>
			
		 </ext:Window>
	    <ext:Window 
	ID="Window3" 
	runat="server" 
	IconCls="iconoCONCYSSA" 
    Width="860" 
    Height="400" 
    Modal="true"
    Hidden="true"
    Layout="Fit"
	 Draggable="false">
	<Content>
		<ext:Panel ID="Panel3" runat="server" Title="Panel Búsqueda" AutoHeight="true" Padding="3">
			<Content>
				<table>
					<tr>
						<td><b>No. Orden</b></td>
						<td style="padding-left:5px;">
							<ext:TextField ID="txtNroOrden" runat="server" Width="80px">
							</ext:TextField>
						</td>
						<td style="padding-left:15px;"><b>SGI</b></td>
						<td style="padding-left:5px;">
							<ext:TextField ID="txtSGI" runat="server" Width="80px">
							</ext:TextField>
						</td>
						<td style="padding-left:15px;">
							<ext:Button ID="Button9" runat="server" Text="Buscar">
								<DirectEvents>
									<Click OnEvent="CargarGrillaBusquedaOT">
                                        <EventMask ShowMask="true" />
                                    </Click>
								</DirectEvents>
							</ext:Button>
						</td>
					</tr>
				</table>
			</Content>
		</ext:Panel>
		<ext:Panel ID="Panel4" runat="server" Title="Panel de Resultados" AutoHeight="true">
			<Items>
				<ext:GridPanel ID="gpnOTs" runat="server" Height="250">
					<Store>
						<ext:Store ID="StoreOT" runat="server" SerializationMode="Complex">
							<Reader>
								<ext:JsonReader IDProperty="IdCabecera">
									<Fields>
										<ext:RecordField Name="IdCabecera" /> 
										<ext:RecordField Name="Obra" /> 
										<ext:RecordField Name="Distrito" /> 
										<ext:RecordField Name="Urbanizacion" /> 
										<ext:RecordField Name="Direccion" /> 
										<ext:RecordField Name="Cliente" /> 
										<ext:RecordField Name="Sgi" /> 
										<ext:RecordField Name="Suministro" /> 
										<ext:RecordField Name="NumeroOrden" /> 
										<ext:RecordField Name="FechaOrden" /> 
										<ext:RecordField Name="Actividad" /> 
										<ext:RecordField Name="SubActividad" /> 
										<ext:RecordField Name="FechaDigitacion" /> 
										<ext:RecordField Name="FechaProgramacion" /> 
										<ext:RecordField Name="FechaInicio" /> 
										<ext:RecordField Name="HoraInicio" /> 
										<ext:RecordField Name="FechaTermino" /> 
										<ext:RecordField Name="Horatermino" /> 
										<ext:RecordField Name="HorasTrabajadas" /> 
										<ext:RecordField Name="NumeroTrabajadores" /> 
										<ext:RecordField Name="Cuadrilla" /> 
										<ext:RecordField Name="IdZona" /> 
										<ext:RecordField Name="EstadoOT" /> 
                                        <ext:RecordField Name="EstadoOTRO" /> 
										<ext:RecordField Name="Mes" /> 
										<ext:RecordField Name="Anno" /> 
										<ext:RecordField Name="IdValorizacion" /> 
										<ext:RecordField Name="Estado" /> 
									</Fields>
								</ext:JsonReader>
							</Reader>
						</ext:Store>
					</Store>
					<ColumnModel ID="ColumnModel2" runat="server">
						<Columns>
							<ext:Column ColumnID="IdCabecera" Header="IdCabecera" DataIndex="IdCabecera" Hidden="true"/>
							<ext:Column ColumnID="NumeroOrden" Header="No. Orden" DataIndex="NumeroOrden" Width="60px" />
							<ext:Column ColumnID="Sgi" Header="SGI" DataIndex="Sgi" Width="60px" />
							<ext:Column DataIndex="Distrito" Header="Distrito" Width="130px">
								<Renderer Fn="DistritoRenderer" />
							</ext:Column>
							<ext:Column ColumnID="Urbanizacion" Header="Urbanizacion" DataIndex="Urbanizacion" Width="130px" />
							<ext:Column ColumnID="Direccion" Header="Direccion" DataIndex="Direccion" Width="130px" />
							<ext:Column DataIndex="Actividad" Header="Actividad" Width="250px">
								<Renderer Fn="ActividadRenderer" />
							</ext:Column>
							<ext:Column DataIndex="SubActividad" Header="SubActividad" Width="250px">
								<Renderer Fn="SubActividadRenderer" />
							</ext:Column>
						</Columns>
					</ColumnModel>
					<LoadMask ShowMask="true"/>
					<SaveMask ShowMask="true" />
					<SelectionModel>
						<ext:RowSelectionModel ID="RowSelectionModel1" runat="server" />
					</SelectionModel>
					<DirectEvents>
						<RowDblClick OnEvent="RowDblClick_Event" Timeout="3600000">
							<ExtraParams>
								<ext:Parameter Name="Values" Value="Ext.encode(#{gpnOTs}.getRowsValues({selectedOnly:true}))" Mode="Raw" />
							</ExtraParams>
						</RowDblClick>
					</DirectEvents>
				</ext:GridPanel>
			</Items>
		</ext:Panel>
	</Content>
</ext:Window>
        <ext:Window 
            ID="Window5" 
            runat="server" 
            Icon="LinkAdd" 
            Title="Ingreso de Nuevo Cargo" 
            Hidden="true" 
			Width="300px" AutoHeight="true">
			<Content>
                <table>
                    <tr>
                        <td style="padding-left:5px;">Nombre del Cargo</td>
                        <td>
                            <ext:TextField ID="txtNomCargo" runat="server">
                            </ext:TextField>
                        </td>
                    </tr>
                </table>
            </Content>
            <Buttons>
                <ext:Button ID="btnIngresaCargo" Icon="Disk" runat="server" Text="Agregar">
					<DirectEvents>
						<Click OnEvent="btnIngresaCargo_Click"></Click>
					</DirectEvents>
				</ext:Button>
            </Buttons>
        </ext:Window>

    </form>
</body>
</html>
