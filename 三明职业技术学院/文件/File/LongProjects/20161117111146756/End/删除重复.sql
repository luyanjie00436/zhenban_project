declare 
@i int =1,
@OldId int
while (@i<1400)
begin
if exists (select * from UseJobPost where id=@i)
begin
set @OldId=(select UseJobPostId from UseJobPost where id=@i )
if exists (select * from UseJobPost where id<>@i and UseJobPostId=@OldId)
begin
delete UseJobPost where id<>@i and UseJobPostId=@OldId
end

end





set @i=@i+1
end