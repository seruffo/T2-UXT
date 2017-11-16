 <?php
 	 function clean($string) {
	   $string = str_replace(' ', '-', $string); // Replaces all spaces with hyphens.

	   return preg_replace('/[^A-Za-z0-9\-]/', '', $string); // Removes special chars.
	}
	if ($_SERVER["REQUEST_METHOD"] == "POST")
	{
	
		$data = json_decode($_POST["data"]);
		$Sample = clean($data->$sample);

		if($imageData != null)
		{
			$imageData = base64_decode(preg_replace('#^data:image/\w+;base64,#i', '', $data->$imageData));
			$source = imagecreatefromstring($imageData);
			$imageSave = imagejpeg($source,'Samples/'.$Sample.'/'.$data->$userId.'/'.$data->$time.".jpg",100);
			imagedestroy($source);
			$txt = "<trace type=\"".$data->$type."\" image=\"".$data->$time.".jpg\" time=\"".$data->$time."\" mouseId=\"".$data->$mouse->$id." mouseX=\"".$data->$mouse->$X."\" mouseY=\"".$data->$mouse->$Y."\" keyId=\"".$data->$keyboard->$id."\" keys=\"".$data->$keyboard->$typed."\" keyX=\"".$data->$keyboard->$X."\" keyY=\"".$data->$keyboard->$Y."\"\>";
			file_put_contents('Samples/'.$Sample.'/'.$data->$userId.'/trace.xml', $txt.PHP_EOL , FILE_APPEND | LOCK_EX);
			$handle = fopen('Samples/'.$Sample.'/'.$data->$userId.'/lastTime.txt',"w");
			$content = fwrite($handle,$time);
			fclose($handle);
		}
		echo "Bagulho chegou sim!";
	}
 ?>