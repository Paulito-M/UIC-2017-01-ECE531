function [ av_digits ] = get_avdigits( digits )

av_digits=[];


for d = 1:10
    digit=digits{d};
    av_digits{d}=get_avdigit( digit );
end

end