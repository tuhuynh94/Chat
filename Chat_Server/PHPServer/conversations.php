<?php

$servername = "localhost";
$username = "root";
$password = "";
$dbname = "chat";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}
$conn->set_charset("utf8");

$phone = $_POST["phone"];


$sql = "SELECT conversation_id, conversation_name, creator, created_at, updated_at FROM conversations WHERE phone = '" . $phone . "' ";
$result = $conn->query($sql);

if ($result->num_rows > 0) {

    $row = $result->fetch_assoc();

} else {
    echo "s::0 this user is not exists";
}
$conn->close();

?>