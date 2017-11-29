 <?php
 	 function clean($string) {
	   $string = str_replace(' ', '-', $string); // Replaces all spaces with hyphens.

	   return preg_replace('/[^A-Za-z0-9\-]/', '', $string); // Removes special chars.
	}
	if ($_SERVER["REQUEST_METHOD"] == "POST")
	{
		echo "result ";
		$data = json_decode($_POST['metadata']);
		$keyboard = json_decode($_POST['keyboard']);
		$mouse = json_decode($_POST['mouse']);
		//var_dump($data);
		$Sample = clean($data->sample);
		echo $Sample;
		if($data->imageData != null)
		{
			$imageData = base64_decode(preg_replace('#^data:image/\w+;base64,#i', '', $data->imageData));
			$source = imagecreatefromstring($imageData);
			$imageSave = imagejpeg($source,'Samples/'.$Sample.'/'.$data->userId.'/'.$data->time.".jpg",100);
			imagedestroy($source);
			$txt = "<rawtrace type=\"".$data->type."\" image=\"".$data->time.".jpg\" time=\"".$data->time."\" mouseId=\"".$mouse->id."\" mouseX=\"".$mouse->X."\" mouseY=\"".$mouse->Y."\" keyId=\"".$keyboard->id."\" keys=\"".$keyboard->typed."\" keyX=\"".$keyboard->x."\" keyY=\"".$keyboard->y."\"/>";
			file_put_contents('Samples/'.$Sample.'/'.$data->userId.'/trace.xml', $txt.PHP_EOL , FILE_APPEND | LOCK_EX);
			$handle = fopen('Samples/'.$Sample.'/'.$data->userId.'/lastTime.txt',"w");
			$content = fwrite($handle,$data->time);
			fclose($handle);
		}
	}
 ?>