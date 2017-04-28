function [ meanvectors ] = get_meanvectors( )
%
% USAGE: meanvectors = get_meanvectors( )
%
%   meanvectors{ 1 } returns the meanvector of digit 1
%   meanvectors{ 10 } returns the meanvector of digit 0
%
% invoke get_meanvector() to create and return the array of
% meanvectors for digits 0 through 9
%

digits=[];
meanvectors=[];

% threshold is the pixel intensity value between OFF and ON
threshold = 75;

% invoke read_mnist_files() to retrieve the MNIST bitmaps for
% digits 0 through 9
digits = read_mnist_files();

% invoke get_meanvectors() to calculate the mean vectors  
% from the MNIST data

for digit = 1:10
  meanvectors{ digit } = get_meanvector( digits{ digit }, threshold );      
end

end
