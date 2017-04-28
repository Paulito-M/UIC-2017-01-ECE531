function [ covarmatrices ] = get_covarmatrices(  )
%
% USAGE:
%

digits=[];
meanvectors=[];
covarmatrices = [];

% threshold is the pixel intensity value between OFF and ON
threshold = 75;

% invoke read_mnist_files() to retrieve the MNIST bitmaps for
% digits 0 through 9
digits = read_mnist_files();

% invoke get_meanvectors() to calculate the mean vectors  
% from the MNIST data

for digit = 1:10
  meanvectors{ digit } = get_meanvector( digits{ digit }, threshold );  
  covarmatrices{ digit } = get_covarmatrix( digits{ digit }, meanvectors{ digit }, threshold ) 
  covarmatrices{ digit } = covarmatrices{ digit } + 0.1*eye(784); 
end

end
