function [ avg_digit ] = get_avdigit( digit )


avg= [];
digitsize=size( digit );
numchars = digitsize( 3 );

for row = 1:28
    for col = 1:28
        avg( row, col ) = 0.0;
        for chars = 1:numchars
          avg( row, col ) = avg(row, col) + digit(row,col,chars );
        end
        avg( row, col ) = avg( row, col ) / numchars;
    end 
end

avg_digit = avg;

end
        