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
		if(!file_exists("Samples")){
			mkdir("Samples");
		}else{
			if(!file_exists('Samples/'.$Sample)){
				mkdir('Samples/'.$Sample);
			}else{
				if(!file_exists('Samples/'.$Sample.'/'.$metadata->userId)){
					mkdir('Samples/'.$Sample.'/'.$metadata->userId);
				}
			}
		}
		if($data->imageData != "NO")
		{
			if(!(file_exists('Samples/'.$Sample.'/'.$metadata->userId.'/'.$data->imageName)))
			{
				$imageData = base64_decode(preg_replace('#^data:image/\w+;base64,#i', '', $data->imageData));
				$source = imagecreatefromstring($imageData);
				$imageSave = imagejpeg($source,'Samples/'.$Sample.'/'.$metadata->userId.'/'.$data->imageName,100);
				imagedestroy($source);
			}
		}
		//if($metadata->type=="eye"){
		//	$txt = $data->X;
		//	file_put_contents('Samples/'.$Sample.'/'.$metadata->userId.'/traceX.txt', $txt.PHP_EOL , FILE_APPEND | LOCK_EX);
		//	$txt = $data->Y;
		//	file_put_contents('Samples/'.$Sample.'/'.$metadata->userId.'/traceY.txt', $txt.PHP_EOL , FILE_APPEND | LOCK_EX);
		//	$txt = $metadata->time;
		//	file_put_contents('Samples/'.$Sample.'/'.$metadata->userId.'/traceTime.txt', $txt.PHP_EOL , FILE_APPEND | LOCK_EX);
		//}else{
			$txt = "<rawtrace type=\"".$metadata->type."\" image=\"".$data->imageName."\" time=\"".$metadata->time."\" Class=\"".$data->Class."\" Id=\"".$data->Id."\" MouseClass=\"".$data->mouseClass."\" MouseId=\"".$data->mouseId."\" X=\"".$data->X."\" Y=\"".$data->Y."\" keys=\"".$data->Typed."\" scroll=\"".$metadata->scroll."\" height=\"".$metadata->height."\" url=\"".$metadata->url."\" />";
			file_put_contents('Samples/'.$Sample.'/'.$metadata->userId.'/trace.xml', $txt.PHP_EOL , FILE_APPEND | LOCK_EX);
			$handle = fopen('Samples/'.$Sample.'/'.$metadata->userId.'/lastTime.txt',"w");
			$content = fwrite($handle,$metadata->time);
			fclose($handle);
		
		echo "received ";
	}
 ?>