function test_guess_mgdigit()

count_pass = 0;
count_fail = 0;

% invoke read_mnist_files() to retrieve the MNIST bitmaps for
% digits 0 through 9
digits = read_mnist_files();

meanvectors=[];

threshold = 75;

% invoke get_meanvectors() to calculate the mean vectors  
% from the MNIST data

for digit = 1:10
  meanvectors{ digit } = get_meanvector( digits{ digit }, threshold );  
  covarmatrices{ digit } = get_covarmatrix( digits{ digit }, meanvectors{ digit }, threshold ) 
  covarmatrices{ digit } = covarmatrices{ digit } + 0.1*eye(784); 
end


for digit=1:10
  chararray = digits{ digit };  
  for image=1:1000
      fprintf( 'DIGIT %d IMAGE %d\n', digit, image );
    guess = guess_biggdigit2( chararray(:,:,image), meanvectors, covarmatrices );
    if ( guess == mod( digit, 10 ) )
      count_pass = count_pass + 1;
    else
      count_fail = count_fail + 1;
    end
  end
end

fprintf( 'PASS = %d FAIL = %d\n', count_pass, count_fail );
end
