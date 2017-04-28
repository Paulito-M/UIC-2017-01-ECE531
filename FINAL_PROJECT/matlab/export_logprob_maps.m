function export_logprob_maps( )
%
% USAGE: export_logprob_maps()
%
%  Exports the MINST database trained log pixel probability maps
%  to individual files named logppmap_ON<digit>.csv and
%  logppmap_OFF<digit>.csv

ppmaps=[];

logppmaps_ON=[];
logppmaps_OFF=[];

% initialize the MNIST database and its copies
ppmaps = get_pixprob_maps();
logppmap_ON=[];
logppmap_OFF=[];

for digit = 1:10
  fprintf( 'DIGIT IS %d\n', mod( digit, 10 ) );
  
  ppmap = ppmaps{ digit };
  
  for row = 1:28
    for col = 1:28
      logppmap_ON( row, col ) = log( ppmap( row, col ) );
      logppmap_OFF( row, col ) = log( 1 - ppmap( row, col ) );
    end
  end

  fname = strcat( 'logppmap_ON', int2str( mod( digit, 10 ) ) );
  fname = strcat( fname, '.csv');
  fprintf( 'FILENAME IS %s\n', fname );  
  csvwrite( fname, logppmap_ON)

  fname = strcat( 'logppmap_OFF', int2str( mod( digit, 10 ) ) );
  fname = strcat( fname, '.csv');
  fprintf( 'FILENAME IS %s\n', fname );  
  csvwrite( fname, logppmap_OFF)

end  
  