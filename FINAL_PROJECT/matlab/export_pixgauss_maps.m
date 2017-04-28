function export_pixgauss_maps( )
%
% USAGE: export_pixgauss_maps()
%
%  Exports the MINST database trained pixel mean & variance maps
%  to individual files named pgmap<digit>_MEAN.csv, pgmap<digit>_VAR.csv

pgmaps=[];

% initialize the MNIST database 
pgmaps = get_pixgauss_maps();

for digit = 1:10
  fprintf( 'DIGIT IS %d\n', mod( digit, 10 ) );
  
  fname = strcat( 'pgmap', int2str( mod( digit, 10 ) ) );
  fname = strcat( fname, '_MEAN.csv');
  fprintf( 'FILENAME IS %s\n', fname );
  
  pgmap = pgmaps{ digit };
  csvwrite( fname, pgmap(:,:,1) );

  fname = strcat( 'pgmap', int2str( mod( digit, 10 ) ) );
  fname = strcat( fname, '_VAR.csv');
  fprintf( 'FILENAME IS %s\n', fname );
  
  csvwrite( fname, pgmap(:,:,2) );
  
end

end