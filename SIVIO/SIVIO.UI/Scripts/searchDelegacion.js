
<script type="text/javascript">
    $(document).ready(function () {
        $("#btnBusquedaExpediente").click(function () {
            $.LoadingOverlay("show");
            $.ajax({
                type: "POST",
                url: '@Url.Action("BusquedaExpediente", "Expediente")' + "?" + $("#frmBusqueda").serialize(),
                async: true,
            }).done(function (data) {
                $.LoadingOverlay("hide");
                $('#contendorFrames').html(data);
                $("#contenedorEspera").hide();
                $('#contendorFrames').fadeIn();
            }).fail(function (exception) {
                $("#txtModalTitulo").css("color", "red");
                $("#txtModalTitulo").text("Error de Sistema");
                $("#txtModalContenido").text("Fallo al cargar la pantalla, contacte a la persona administradora de SIPAMU");
                $("#contenedorEspera").hide();
                instMensajes.open();
                $.LoadingOverlay("hide");
            });
        });
    });

</script>
