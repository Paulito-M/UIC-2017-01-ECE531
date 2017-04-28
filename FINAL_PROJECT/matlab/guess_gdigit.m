function [ digit ] = guess_digit( bitmapX, pgmaps )
%
% USAGE: digit = guess_gdigit( bitmapX, pgmaps )
%
%   return best guess of digit (0 through 9) represented by
%   28x28 grayscale bitmapX, based on MNIST database and
%   using Gaussian naive Bayes discriminator
%
%   pgmaps is array of pixel Gaussian maps returned by 
%   get_pixgauss_maps
%

logprobs=[];

% calculate Gaussian log probabilities over all digits 
for digit = 1:10
  logprobs( digit ) = get_gaussprob_YgivenX( pgmaps{ digit }, bitmapX );
end

[ maxlogprob, digit ] = max( logprobs );


if ( digit == 10 ) 
  digit = 0;
end

%fprintf( 'BEST GUESS IS %d\n', digit );

end

      
