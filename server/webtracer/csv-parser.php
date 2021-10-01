<?php
	if ($_SERVER["REQUEST_METHOD"] == "POST")
	{
        $data = json_decode($_POST['data']);
        file_put_contents('output.csv', $data.PHP_EOL , FILE_APPEND | LOCK_EX);
    }
?>