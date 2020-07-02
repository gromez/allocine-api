<?php

require_once(__DIR__.'/allocine.class.php');

define('ALLOCINE_PARTNER_KEY', '100ED1DA33EB');
define('ALLOCINE_SECRET_KEY', '1a1ed8c1bed24d60ae3472eed1da33eb');

$allocine = new Allocine(ALLOCINE_PARTNER_KEY, ALLOCINE_SECRET_KEY);

$result = $allocine->search('Oblivion');

echo $result;