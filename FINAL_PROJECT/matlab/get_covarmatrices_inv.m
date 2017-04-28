function [ covarmatrices_inv ] = get_covarmatrices_inv( covarmatrices )
%
% USAGE:
%

for digit = 1:10
  covarmatrices_inv{ digit } = inv( covarmatrices{ digit } );
end

end
