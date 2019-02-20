 <?php
 	 function clean($string) {
	   $string = str_replace(' ', '-', $string); // Replaces all spaces with hyphens.

	   return preg_replace('/[^A-Za-z0-9\-]/', '', $string); // Removes special chars.
	}
	if ($_SERVER["REQUEST_METHOD"] == "POST")
	{
		$metadata = json_decode($_POST['metadata']);
		$data = json_decode($_POST['data']);
		$Sample = clean($metadata->sample);
		if($data->imageData != null)
		{
			if(!(file_exists('Samples/'.$Sample.'/'.$metadata->userId.'/'.$metadata->time.".jpg")))
			{
				$imageData = base64_decode(preg_replace('#^data:image/\w+;base64,#i', '', $data->imageData));
				$source = imagecreatefromstring($imageData);
				$imageSave = imagejpeg($source,'Samples/'.$Sample.'/'.$metadata->userId.'/'.$metadata->time.".jpg",100);
				imagedestroy($source);
			}
			$txt = "<rawtrace type=\"".$metadata->type."\" image=\"".$metadata->time.".jpg\" time=\"".$metadata->time."\" Class=\"".$data->Class."\" Id=\"".$data->Id."\" MouseClass=\"".$data->mouseClass."\" MouseId=\"".$data->mouseId."\" X=\"".$data->X."\" Y=\"".$data->Y."\" keys=\"".$data->Typed."\" scroll=\"".$metadata->scroll."\" height=\"".$metadata->height."\" url=\"".$metadata->url."\" />";
			file_put_contents('Samples/'.$Sample.'/'.$metadata->userId.'/trace.xml', $txt.PHP_EOL , FILE_APPEND | LOCK_EX);
			$handle = fopen('Samples/'.$Sample.'/'.$metadata->userId.'/lastTime.txt',"w");
			$content = fwrite($handle,$metadata->time);
			fclose($handle);
		}
		echo "received";
	}
 ?>