local BaseClass = require "Core/BaseClass"

mainServer = class("mainClass",BaseClass)

function mainServer:ctor()
end

function mainServer:test(id,mess)
	print("ID:" .. id .. " message:" .. mess)
	local  test = {
		[1] = "111",
		[2] = "111",
		[3] = "111",
	}

	sendMessage(id,self:ToStringEx(test))
end

local instance = mainServer.new()
instance:test(tokenID,message)