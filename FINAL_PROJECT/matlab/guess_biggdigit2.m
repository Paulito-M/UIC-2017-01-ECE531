function [ digit ] = guess_biggdigit2( bitmapX, meanvectors, covarmatrices )
%
% USAGE: digit = guess_biggdigit( bitmapX, meanvectors, covarmatrices )
%

% calculate mulitvariate Gaussian log probabilities over all digits 
for digit = 1:10
  logprobs( digit ) = get_mgaussprob_YgivenX( meanvectors{ digit }, covarmatrices{ digit }, bitmapX );
end

[ maxlogprob, digit ] = max( logprobs );


if ( digit == 10 ) 
  digit = 0;
end

%fprintf( 'BEST GUESS IS %d\n', digit );

end

      
