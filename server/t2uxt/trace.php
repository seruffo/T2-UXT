<?php
 	 function clean($string) {
	   $string = str_replace(' ', '-', $string); // Replaces all spaces with hyphens.

	   return preg_replace('/[^A-Za-z0-9\-]/', '', $string); // Removes special chars.
	}
	if ($_SERVER["REQUEST_METHOD"] == "POST")
	{
		$inputData = file_get_contents('php://input');
		$inputJSON = json_decode($inputData);
		$metadata = $inputJSON->metadata;
		$data = $inputJSON->data;
		$Sample = clean($metadata->sample);
		if(!file_exists("samples")){
			mkdir("samples");
		}else{
			if(!file_exists('samples/'.$Sample)){
				mkdir('samples/'.$Sample);
			}else{
				if(!file_exists('samples/'.$Sample.'/'.$metadata->userId)){
					mkdir('samples/'.$Sample.'/'.$metadata->userId);
				}
			}
		}
		if($data->imageData != "NO")
		{
			if(!(file_exists('samples/'.$Sample.'/'.$metadata->userId.'/'.$data->imageName)))
			{
				$imageData = base64_decode(preg_replace('#^data:image/\w+;base64,#i', '', $data->imageData));
				$source = imagecreatefromstring($imageData);
				$imageSave = imagejpeg($source,'samples/'.$Sample.'/'.$metadata->userId.'/'.$data->imageName,100);
				imagedestroy($source);
			}
		}
		//if($metadata->type=="eye"){
		//	$txt = $data->X;
		//	file_put_contents('samples/'.$Sample.'/'.$metadata->userId.'/traceX.txt', $txt.PHP_EOL , FILE_APPEND | LOCK_EX);
		//	$txt = $data->Y;
		//	file_put_contents('samples/'.$Sample.'/'.$metadata->userId.'/traceY.txt', $txt.PHP_EOL , FILE_APPEND | LOCK_EX);
		//	$txt = $metadata->time;
		//	file_put_contents('samples/'.$Sample.'/'.$metadata->userId.'/traceTime.txt', $txt.PHP_EOL , FILE_APPEND | LOCK_EX);
		//}else{
			$txt = "<rawtrace type=\"".$data->type."\" image=\"".$data->imageName."\" time=\"".$metadata->time."\" Class=\"".$data->class."\" Id=\"".$data->id."\" MouseClass=\"".$data->mouseClass."\" MouseId=\"".$data->mouseId."\" X=\"".$data->x."\" Y=\"".$data->y."\" keys=\"".$data->typed."\" scroll=\"".$metadata->scroll."\" height=\"".$metadata->height."\" url=\"".$metadata->url."\" />";
			file_put_contents('samples/'.$Sample.'/'.$metadata->userId.'/trace.xml', $txt.PHP_EOL , FILE_APPEND | LOCK_EX);
			$handle = fopen('samples/'.$Sample.'/'.$metadata->userId.'/lastTime.txt',"w");
			$content = fwrite($handle,$metadata->time);
			fclose($handle);
		
		echo "received ";
	}
 ?>