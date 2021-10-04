 <?php
	 function clean($string) {
	   $string = str_replace(' ', '-', $string); // Replaces all spaces with hyphens.

	   return preg_replace('/[^A-Za-z0-9\-]/', '', $string); // Removes special chars.
	}
	if ($_SERVER["REQUEST_METHOD"] == "POST")
	{
		$inputJSON = file_get_contents('php://input');
		$data = json_decode($inputJSON);
		$userId = clean($data->userId);
		$domain = clean($data->domain);
		if (!file_exists('samples/'.$domain.'/'.$userId))
		{
			mkdir('samples/'.$domain.'/'.$userId, 0777, true);
		}
		$filename = 'samples/'.$domain.'/'.$userId.'/lastTime.txt';
		if (file_exists($filename))
		{
			$handle = fopen($filename,"r");
			$content = fread($handle,filesize($filename));
			fclose($handle);
			echo $content;
		}
		else
		{
			echo 0;
		}
	}
 ?>