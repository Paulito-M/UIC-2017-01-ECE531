function test_guess_digit()

ppmaps=[];
count_pass = 0;
count_fail = 0;

% initialize the MNIST database 
ppmaps = get_pixprob_maps();

% invoke read_mnist_files() to retrieve the MNIST bitmaps for
% digits 0 through 9
digits = read_mnist_files();

for digit=1:10
  chararray = digits{ digit };  
  for image=1:1000
    guess = guess_digit( chararray(:,:,image), ppmaps );
    if ( guess == mod( digit, 10 ) )
      count_pass = count_pass + 1;
    else
      count_fail = count_fail + 1;
    end
  end
end

fprintf( 'PASS = %d FAIL = %d\n', count_pass, count_fail );
end
