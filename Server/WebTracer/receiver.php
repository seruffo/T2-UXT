 <?php
 	 function clean($string) {
	   $string = str_replace(' ', '-', $string); // Replaces all spaces with hyphens.

	   return preg_replace('/[^A-Za-z0-9\-]/', '', $string); // Removes special chars.
	}
	if ($_SERVER["REQUEST_METHOD"] == "POST")
	{
		$imageData = $_POST["image"];
		$Sample = clean($_POST["sample"]);
		$userId = $_POST["userId"];
		$type = $_POST["type"];
		$posx = $_POST["posx"];
		$posy = $_POST["posy"];
		$time = $_POST["time"];
		$keys = $_POST["keys"];
		if($imageData != null)
		{
			$imageData = base64_decode(preg_replace('#^data:image/\w+;base64,#i', '', $imageData));
			$source = imagecreatefromstring($imageData);
			$imageSave = imagejpeg($source,'Samples/'.$Sample.'/'.$userId.'/'.$time.".jpg",100);
			imagedestroy($source);
			$txt = "<trace type=\"".$type."\" image=\"".$time.".jpg\" time=\"".$time."\" x=\"".$posx."\" y=\"".$posy."\" keys=\"".$keys."\"\>";
			file_put_contents('Samples/'.$Sample.'/'.$userId.'/trace.xml', $txt.PHP_EOL , FILE_APPEND | LOCK_EX);
			$handle = fopen('Samples/'.$Sample.'/'.$userId.'/lastTime.txt',"w");
			$content = fwrite($handle,$time);
			fclose($handle);
		}
		echo "Bagulho chegou sim!";
	}
 ?>