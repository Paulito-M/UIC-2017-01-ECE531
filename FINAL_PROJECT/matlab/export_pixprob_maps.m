function export_pixprob_maps( )
%
% USAGE: export_pixprob_maps()
%
%  Exports the MINST database trained pixel probability maps
%  to individual files named ppmap<digit>.csv

ppmaps=[];

% initialize the MNIST database 
ppmaps = get_pixprob_maps();

for digit = 1:10
  fprintf( 'DIGIT IS %d\n', mod( digit, 10 ) );
  
  fname = strcat( 'ppmap', int2str( mod( digit, 10 ) ) );
  fname = strcat( fname, '.csv');
  fprintf( 'FILENAME IS %s\n', fname );
  
  csvwrite( fname, ppmaps{digit})
  
end

end