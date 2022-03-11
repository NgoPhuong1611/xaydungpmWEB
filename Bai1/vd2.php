<?php
$kw=$_GET['kw'];
$o=new PDO ('mysql:host=localhost;dbname=bookstore','root','');
$o->query{'set names utf8'};
$sql="select * from book where book_name like'%$kw%'";
$stm =$o ->query($sql);
$data = $stm -> fetchAll(PDO::FETCH_ASSOC);
echo json_encode($data);