<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Main.Master" AutoEventWireup="true" CodeBehind="article.aspx.cs" Inherits="uSwitch.FacebookApp.Example.article" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h2>Some article</h2>
<div style="width:200px; float:right">
    <input type="button" id="shareStory" value="Share on facebook" />
</div>

    <div id="lipsum">
<p>
Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris
faucibus dapibus nibh. Curabitur egestas augue euismod metus. Sed ante
odio, fermentum egestas, posuere non, placerat sit amet, lectus. Donec
tincidunt, neque in egestas suscipit, est diam scelerisque dui, nec
lobortis felis orci sit amet nunc. Etiam tristique dolor sed risus.
Maecenas quis velit. Curabitur ut nibh. Nam commodo, urna id suscipit
fringilla, justo dui mollis erat, ac cursus libero est et lorem. Proin
aliquet dapibus augue. Proin tincidunt nunc et lorem. Pellentesque a
orci. Donec ultrices tortor eu ligula. Donec augue metus, bibendum nec,
facilisis et, suscipit a, sapien. Donec dapibus sodales libero.
</p>
<p>Sed nec orci eu elit lobortis porta. Fusce dignissim rhoncus neque.
Etiam sit amet diam vel nisi convallis aliquam. Quisque scelerisque
erat non lorem. Nam sollicitudin. Mauris porta purus in lacus. Morbi
molestie nisi ac nisi. Integer velit sapien, blandit sed, volutpat in,
posuere nec, lacus. Pellentesque libero dui, rutrum suscipit, accumsan
et, posuere eu, ipsum. Praesent faucibus erat. Pellentesque vulputate
eleifend velit. Proin venenatis nisi at tortor. Integer sed ipsum in
est iaculis aliquam. Suspendisse sit amet felis. Morbi euismod tortor
ut dui. Mauris nibh est, feugiat facilisis, tristique vel, ultrices et,
dui. Mauris eget nunc. Suspendisse potenti.
</p>
<p>Nunc eu nunc vel erat dictum commodo. Pellentesque habitant morbi
tristique senectus et netus et malesuada fames ac turpis egestas.
Curabitur vitae elit. Pellentesque habitant morbi tristique senectus et
netus et malesuada fames ac turpis egestas. In ac metus a enim bibendum
accumsan. Mauris nec tellus. Praesent tincidunt ligula a est. Aliquam
nec enim. Cum sociis natoque penatibus et magnis dis parturient montes,
nascetur ridiculus mus. Donec euismod, massa ac malesuada egestas,
ipsum nunc vehicula massa, id tincidunt nulla justo ac enim. Duis ac
lorem. Phasellus malesuada. Maecenas ullamcorper dictum purus.
Pellentesque habitant morbi tristique senectus et netus et malesuada
fames ac turpis egestas. Morbi at felis non mauris tempor porta. Mauris
eu dolor. Proin non neque. Nam ligula neque, ornare ac, accumsan sit
amet, convallis id, neque. Quisque id augue. Sed ac justo.
</p>
<p>Sed gravida sagittis lorem. Morbi lorem. Proin faucibus, ligula eu
volutpat tempor, augue mi consequat nulla, eu auctor justo tellus at
enim. Fusce vitae ipsum non metus porttitor vehicula. Fusce et augue.
In diam urna, fermentum eget, commodo in, dictum quis, augue. Vivamus
rutrum pretium arcu. Sed arcu urna, adipiscing non, vehicula eu, tempus
id, dui. Integer ante tellus, accumsan nec, dictum ut, vehicula
condimentum, ante. Suspendisse nibh nisl, viverra a, iaculis in,
placerat vel, augue. Nulla lobortis urna laoreet magna. Duis tempor
erat suscipit quam. In vel magna. Curabitur dignissim justo eu risus.
</p>
<p>Pellentesque faucibus nulla eget magna tristique auctor. In lobortis
commodo erat. Cras at justo et massa posuere molestie. Etiam eget nisl
sit amet elit scelerisque posuere. Pellentesque vel enim id nulla
interdum varius. Aliquam sodales risus nec leo. Vestibulum nulla
tortor, tincidunt ut, tempus ac, tristique sed, elit. In hac habitasse
platea dictumst. Donec lacus dui, faucibus id, aliquam vel, fringilla
sed, ligula. Duis placerat fermentum magna. Vestibulum interdum elit
nec nisl.
</p></div>

<script type="text/javascript">
    $(document).ready(function() {
        $("#shareStory").click(function() {

            var callBack = function() {  };
            FB.Connect.showShareDialog('http://localhost:49652/article.aspx', callBack);
        });
    });
</script>
</asp:Content>
